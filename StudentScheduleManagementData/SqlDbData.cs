using StudentScheduleManagementModel;
using System.Data.SqlClient;

namespace StudentScheduleManagementData
{
    public class SqlDbData
    {

        string connectionString
        = "Data Source =LAPTOP-3VKK1J8H\\SQLEXPRESS; Initial Catalog = StudentScheduleManagement; Integrated Security = True;";
        //Name po ng laptop ko yung Server name sa DataBase
        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT studentno, password, email FROM users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string StudentNo = reader["studentno"].ToString();
                string Email = reader["email"].ToString();
                string Password = reader["password"].ToString();


                User readUser = new User();
                readUser.studno = StudentNo;
                readUser.password = Password;
                readUser.email = Email;
                

                users.Add(readUser);
            }

            sqlConnection.Close();

            return users;
        }

        public int AddUser(string studno, string password, string email)
        {
            int success;

            string insertStatement = "INSERT INTO users VALUES (@studno, @password, @email)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            insertCommand.Parameters.AddWithValue("@studno", studno);
            insertCommand.Parameters.AddWithValue("@password", password);
            insertCommand.Parameters.AddWithValue("@email", email);
            sqlConnection.Open();

            success = insertCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int UpdateUser(string studno, string password, string email)
        {
            int success;

            string updateStatement = $"UPDATE users SET password = @Password WHERE username = @username";
            SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection);
            sqlConnection.Open();

            updateCommand.Parameters.AddWithValue("@password", password);
            updateCommand.Parameters.AddWithValue("@studentno", studno);
            updateCommand.Parameters.AddWithValue("@email", email);

            success = updateCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string studno)
        {
            int success;

            string deleteStatement = $"DELETE FROM users WHERE username = @username";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@studno", studno);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}