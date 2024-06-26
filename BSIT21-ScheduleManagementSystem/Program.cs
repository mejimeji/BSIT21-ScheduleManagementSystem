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

            foreach (var item in users)
            {
                Console.WriteLine(item.studno);
                Console.WriteLine(item.password);
            }

        }
    }
}