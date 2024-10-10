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
          
        public bool CreateUser(string studno, string email, string password)
        {
            User user = new User 
            { 
                studno = studno, 
                email = email, 
                password = password,
                

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

        public bool UpdateUser(string Email, int Status)
        {
            User user = new User {email = Email, dateVerified = DateTime.Now, dateUpdated = DateTime.Now,  status = Status };

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

        public bool DeleteUser(string studno)
        {
            User user = new User { studno = studno };

            return DeleteUser(user);
        }
    }
}