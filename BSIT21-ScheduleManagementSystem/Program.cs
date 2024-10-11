using CustomerManagementServices;
using StudentScheduleManagementModel;
using StudentScheduleManagementService;

namespace Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            EmailServices mail = new EmailServices();

            UserGetServices getServices = new UserGetServices();
            UserTransactionServices usertransactionservices = new UserTransactionServices();

            var users = getServices.GetUsersByStatus(1);

            Console.WriteLine("BSIT 2-1 STUDENTS");
            Console.WriteLine("");
            Console.WriteLine("");


            Console.WriteLine("1 View All Students");
            Console.WriteLine("2 Add a New Student");
            Console.WriteLine("3 Update a Student Status");
            Console.WriteLine("4 Delete a Student");
            Console.WriteLine("");
            Console.WriteLine("");

            string option = Console.ReadLine();

            if (int.TryParse(option, out int num))
            {
                switch (num)
                {
                    case 1:
                        // View All Students
                        Console.WriteLine("");
                        foreach (var item in users)
                        {
                            Console.WriteLine("Student Number: " + item.studno);
                            Console.WriteLine("Email: " + item.email);
                            Console.WriteLine("Password: " + item.password);
                            Console.WriteLine("Profile: " + item.profile);
                            Console.WriteLine("Date Updated: " + item.dateUpdated);
                            Console.WriteLine("Date Verified: " + item.dateVerified);
                            Console.WriteLine("Status: " + item.status);
                            Console.WriteLine("");
                            Console.WriteLine("");
                        }
                        Console.ReadKey();
                        break;

                    case 2:
                        // Add a New Student
                        Console.WriteLine("");
                        Console.WriteLine("Student Number:");
                        string studno = Console.ReadLine();
                        Console.WriteLine("Email:");
                        string email = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string password = Console.ReadLine();

                        if (usertransactionservices.CreateUser(studno, email, password))
                        {
                            Console.WriteLine("Student Information saved successfully!");
                            mail.AddStudentEmail();
                        }
                        else
                        {
                            Console.WriteLine("Failed to save the Student Info.");
                        }
                        break;
                    case 3:
                        // Update a Student's Status
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Student Email to verify:");
                        string Email = Console.ReadLine();

                        Console.WriteLine("Enter the new Status (1 for active, 0 for inactive):");
                        string statusInput = Console.ReadLine();

                        if (int.TryParse(statusInput, out int status))
                        {
                            
                            if (usertransactionservices.UpdateUser(Email, status))
                            {
                                Console.WriteLine("Student status updated successfully!");
                                mail.UpdateStudentEmail();
                            }
                            else
                            {
                                Console.WriteLine("Failed to update the Student status. Please check if the email is correct.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid status. Please enter 1 for active or 0 for inactive.");
                        }
                        break;

                    case 4:
                        // Delete a Student
                        Console.WriteLine("");
                        Console.WriteLine("Enter the Student Number to delete:");
                        string Studno = Console.ReadLine();

                        
                        if (usertransactionservices.DeleteUser(Studno))
                        {
                            Console.WriteLine("Student deleted successfully!");
                            mail.DeleteStudentEmail();
                        }
                        else
                        {
                            Console.WriteLine("Failed to delete the Student. Please check if the Student Number is correct.");
                        }
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

        }
            }
        }
    
