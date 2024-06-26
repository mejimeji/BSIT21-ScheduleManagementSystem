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

        public bool CreateUser(string Studno, string password)
        {
            User user = new User { studno = Studno, password = password };

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

        public bool UpdateUser(string Studno, string password)
        {
            User user = new User { studno = Studno, password = password };

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
    }
}