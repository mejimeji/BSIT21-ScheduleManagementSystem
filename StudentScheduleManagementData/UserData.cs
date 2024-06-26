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

            //UserFactory _userFactory = new UserFactory();
            //users = _userFactory.GetDummyUsers();
        }

        public List<User> GetUsers()
        {
            users = sqlData.GetUsers();
            return users;
        }

        public int AddUser(User user)
        {
            return sqlData.AddUser(user.studno, user.password, user.email);
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