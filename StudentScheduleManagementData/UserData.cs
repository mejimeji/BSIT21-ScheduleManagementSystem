using StudentScheduleManagementModel;

namespace StudentScheduleManagementData
{
    public class UserData
    {
        List<User> users;
        SqlDbData sqlData;
        public UserData()
        {
            users = new List<User>();
            sqlData = new SqlDbData();

        }
          
        public List<User> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(User user)
        {
            return sqlData.AddUser(user.studno, user.email, user.password, user.profile, user.dateUpdated, user.dateVerified, user.status);
        }

        public int UpdateUser(User user)
        {
            return sqlData.UpdateUser(user.studno, user.password, user.email);
        }

        public int DeleteUser(User user)
        {
            return sqlData.DeleteUser(user.studno);
        }
    }
}