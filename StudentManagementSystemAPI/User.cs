using StudentScheduleManagementModel;

namespace StudentManagementSystemAPI
{

    public class User
    {
        public string Studno { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public UserProfile Profile { get; set; }
        public DateTime DateUpdated { get; set; }
        public DateTime DateVerified { get; set; }
        public int Status { get; set; }
          
    }
}