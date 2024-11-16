using Amazon.S3;
using Amazon.S3.Transfer;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Threading.Tasks;
using StudentManagementSystemAPI.Controllers;
using Amazon.Runtime;
using Amazon;


namespace StudentManagementSystemAPI.Services
{
    
    public class S3Service : IS3Service
    {
        public readonly IAmazonS3 _s3Client;
        public readonly string _bucketName;
        private string expectedBucketOwner;

        public S3Service(IConfiguration configuration)
        {

            var accessKey = configuration["AWS:AccessKey"];
            var secretKey = configuration["AWS:SecretKey"];
            var region = configuration["AWS:Region"];

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            _s3Client = new AmazonS3Client(credentials, RegionEndpoint.GetBySystemName(region));

            _bucketName = configuration["AWS:BucketName"];
        }

        public async Task<string> UploadFileAsync(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("File cannot be null or empty");
            }

            using var newMemoryStream = new MemoryStream();
            file.CopyTo(newMemoryStream);

            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = newMemoryStream,
                ContentType = file.ContentType,
                BucketName = _bucketName,
                Key = file.FileName
               
                
            };

            var fileTransferUtility = new TransferUtility(_s3Client);
            await fileTransferUtility.UploadAsync(uploadRequest);

            return $"File '{file.FileName}' uploaded successfully to bucket '{_bucketName}'.";
        }

        public async Task<byte[]> DownloadFileAsync(string fileKey)
        {
            var request = new GetObjectRequest
            {
                BucketName = _bucketName,
                Key = fileKey
            };

            using (var response = await _s3Client.GetObjectAsync(request))
            using (var responseStream = response.ResponseStream)
            using (var memoryStream = new MemoryStream())
            {
                await responseStream.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}