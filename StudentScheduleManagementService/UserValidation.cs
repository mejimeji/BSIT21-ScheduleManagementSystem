namespace StudentScheduleManagementService
{
    public class UserValidationServices
    {

        UserGetServices getservices = new UserGetServices();

        public bool CheckIfUserNameExists(string Studno)
        {
            bool result = getservices.GetUser(Studno) != null;
            return result;
        }
          
        public bool CheckIfUserExists(string studno, string password)
        {
            bool result = getservices.GetUser(studno, password) != null;
            return result;
        }

    }
}