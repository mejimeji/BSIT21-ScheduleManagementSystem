namespace StudentScheduleManagementModel
{
    public class User
    {
        public string studno;
        public string password;
        public string email;
        public DateTime dateVerified;
        private DateTime dateCreated = DateTime.Now;
        public DateTime dateUpdated;
        public UserProfile profile;
        public int status;
    }
}