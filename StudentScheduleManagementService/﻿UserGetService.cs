using StudentScheduleManagementData;
using StudentScheduleManagementModel;

namespace StudentScheduleManagementService
{
    public class UserGetServices
    {
        private List<User> GetAllUsers()
        {
            UserData userData = new UserData();

            return userData.GetUsers();

        }


        public User GetUser(string studno, string password)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.studno == studno && user.password == password)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }

        public List<User> GetUsersByStatus(int userStatus)
        {
            List<User> usersByStatus = new List<User>();

            foreach (var user in GetAllUsers())
            {
                if (user.status == userStatus)
                {
                    usersByStatus.Add(user);
                }
            }

            return usersByStatus;
        }

        public User GetUser(string studno)
        {
            User foundUser = new User();

            foreach (var user in GetAllUsers())
            {
                if (user.studno == studno)
                {
                    foundUser = user;
                }
            }

            return foundUser;
        }
    }
}