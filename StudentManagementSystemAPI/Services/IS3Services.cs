using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Amazon.S3;

namespace StudentManagementSystemAPI.Services
{
    public interface IS3Service
    {
        Task<string> UploadFileAsync(IFormFile file);
        Task<byte[]> DownloadFileAsync(string fileKey);
    }
}