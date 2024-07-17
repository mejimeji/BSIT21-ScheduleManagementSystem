using StudentScheduleManagementData;
using StudentScheduleManagementModel;
using StudentScheduleManagementService;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserGetServices getServices = new UserGetServices();

            var users = getServices.GetUsersByStatus(1);

            Console.WriteLine("BSIT 2-1 STUDENTS");
            Console.WriteLine("");
            Console.WriteLine("");

            foreach (var item in users)
            {
                Console.WriteLine("Student Number: " + item.studno);
                Console.WriteLine("Password: "+item.password);
                Console.WriteLine("Date Updated: "+item.dateUpdated);
                Console.WriteLine("Date Verified: "+item.dateVerified);
                Console.WriteLine("Status: "+item.status);
                Console.WriteLine("");
                Console.WriteLine("");
            }

            Console.ReadKey();
        }
    }
}