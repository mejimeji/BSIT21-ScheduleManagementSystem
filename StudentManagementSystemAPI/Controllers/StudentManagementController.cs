using StudentScheduleManagementService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;


namespace AccountManagement.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : Controller
    {
        UserGetServices _userGetServices;
        UserTransactionServices _userTransactionServices;

        public UserController()
        {
            _userGetServices = new UserGetServices();
            _userTransactionServices = new UserTransactionServices();
        }

        [HttpGet]
        public IEnumerable<StudentManagementSystemAPI.User> GetUsers()
        {
            var activeusers = _userGetServices.GetUsersByStatus(1);

            List<StudentManagementSystemAPI.User> users = new List<StudentManagementSystemAPI.User>();

            foreach (var item in activeusers)
            {
                users.Add(new StudentManagementSystemAPI.User { Studno = item.studno, Password = item.password, Email = item.email, DateVerified = item.dateVerified, DateUpdated = item.dateUpdated, Status = item.status });
            }

            return users;
        }

        [HttpPost]
        public JsonResult AddUser(StudentManagementSystemAPI.User request)
        {
            var result = _userTransactionServices.CreateUser(
                request.Studno,
                request.Email,
                request.Password,
                request.DateUpdated,
                request.DateVerified,
                request.Status
            );

            return new JsonResult(result);
        }

        [HttpPatch]
        public JsonResult UpdateUser(StudentManagementSystemAPI.User request)
        {
            var result = _userTransactionServices.UpdateUser(request.Studno, request.Email, request.Password, request.DateVerified, request.DateUpdated, request.Status);

            return new JsonResult(result);
        }

        
        [HttpDelete]
        public JsonResult DeleteUser(StudentManagementSystemAPI.User request)
        {
            
            {
                var result = _userTransactionServices.DeleteUser(request.Studno, request.Email, request.Password, request.DateVerified, request.DateUpdated, request.Status);

                return new JsonResult(result);

            };

            
        }

    }
}
