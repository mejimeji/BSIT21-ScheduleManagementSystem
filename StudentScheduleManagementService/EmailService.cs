using MailKit.Net.Smtp;
using MailKit.Search;
using MimeKit;

namespace CustomerManagementServices
{
    public class EmailServices
    {
        public void AddStudentEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("COLLEGE OF INFOTMATION AND TECHNOLOGY", "do-not-reply@univ.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "New Student!";

            message1.Body = new TextPart("html")
            {
                Text =
                "<h1>Greetings!</h1>" +
                "<p>Your University Have Enrolled a New Student!</p>" +
                "<p><strong>This email was sent to confirm a new erolled student in your school.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("c537f6800a64eb", "ce55be41ba01fe");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public void UpdateStudentEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("COLLEGE OF INFOTMATION AND TECHNOLOGY", "do-not-reply@univ.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "Updated Student Status!";

            message1.Body = new TextPart("html")
            {
                Text =
                "<h1>Greetings!</h1>" +
                "<p>Your University Have Updated a Student Status!</p>" +
                "<p><strong>This email was sent to confirm a new updated student status your school.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("c537f6800a64eb", "ce55be41ba01fe");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        }

        public void DeleteStudentEmail()
        {
            var message1 = new MimeMessage();
            message1.From.Add(new MailboxAddress("COLLEGE OF INFOTMATION AND TECHNOLOGY", "do-not-reply@univ.com"));
            message1.To.Add(new MailboxAddress("User", "user@example.com"));
            message1.Subject = "Deleted Student!";

            message1.Body = new TextPart("html")
            {
                Text =
                "<h1>Greetings!</h1>" +
                "<p>Your University Have Dropped a New Student!</p>" +
                "<p><strong>This email was sent to confirm a new dropped student in your school.</strong></p>"
            };

            using (var client = new SmtpClient())
            {
                try
                {
                    client.Connect("sandbox.smtp.mailtrap.io", 2525, MailKit.Security.SecureSocketOptions.StartTls);

                    client.Authenticate("c537f6800a64eb", "ce55be41ba01fe");

                    client.Send(message1);
                    Console.WriteLine("Email sent successfully through Mailtrap.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error sending email: {ex.Message}");
                }
                finally
                {
                    client.Disconnect(true);
                }
            }
        
            }
        }
    }
