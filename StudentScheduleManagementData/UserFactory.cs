using StudentScheduleManagementModel;

namespace StudentScheduleManagementData
{
    public class UserFactory
    {
        private List<User> dummyUsers = new List<User>();

        public List<User> GetDummyUsers()
        {
            dummyUsers.Add(CreateDummyUser("Capili", "Harvey", "@gmail.com"));
            dummyUsers.Add(CreateDummyUser("Sayo!", "Criselle", "@gmail.com"));
            dummyUsers.Add(CreateDummyUser("Tuazon", "Mattuew", "@gmail.com"));
            dummyUsers.Add(CreateDummyUser("Jazee", "Tanon", "@gmail.com"));

            return dummyUsers;
        }

        private User CreateDummyUser(string password, string studno, string email)
        {
            User user = new User
            {
                studno = studno,
                password = password,
                profile = new UserProfile { emailAddress = email, profileName = studno },
                dateUpdated = DateTime.Now,
                dateVerified = DateTime.Now.AddDays(1),
                
            };

            return user;
        }

    }
}