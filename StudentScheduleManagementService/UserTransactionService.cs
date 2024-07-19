using StudentScheduleManagementData;
using StudentScheduleManagementModel;

namespace StudentScheduleManagementService
{
    public class UserTransactionServices
    {
        UserValidationServices validationServices = new UserValidationServices();
        UserData userData = new UserData();

        public bool CreateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.studno))
            {
                result = userData.AddUser(user) > 0;
            }

            return result;
        }

        public bool CreateUser(string studno, string email, string password, DateTime dateUpdated, DateTime dateVerified, int status)
        {
            User user = new User 
            { 
                studno = studno, 
                email = email, 
                password = password,
                dateUpdated = dateUpdated,
                dateVerified = dateVerified,
                status = status 

            };


            return CreateUser(user);
        }

        public bool UpdateUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.studno))
            {
                result = userData.UpdateUser(user) > 0;
            }

            return result;
        }

        public bool UpdateUser(string Studno, string Email, string Password, DateTime DateVerified, DateTime DateUpdated, int Status)
        {
            User user = new User { studno = Studno, email = Email, password = Password, dateVerified = DateVerified, dateUpdated = DateUpdated, status = Status };

            return UpdateUser(user);
        }

        public bool DeleteUser(User user)
        {
            bool result = false;

            if (validationServices.CheckIfUserNameExists(user.studno))
            {
                result = userData.DeleteUser(user) > 0;
            }

            return result;
        }

        public bool DeleteUser(string Studno, string Email, string Password, DateTime DateVerified, DateTime DateUpdated, int Status)
        {
            User user = new User { studno = Studno, email = Email, password = Password, dateVerified = DateVerified, dateUpdated = DateUpdated, status = Status };

            return DeleteUser(user);
        }
    }
}