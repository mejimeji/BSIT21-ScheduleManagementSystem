using StudentScheduleManagementModel;
using System.Data.SqlClient;

namespace StudentScheduleManagementData
{
    public class SqlDbData
    {

        string connectionString
        = "Server=localhost\\SQLEXPRESS;Database=ScheduleManagementSystemdb;Trusted_Connection=True;";
        //Name po ng laptop ko yung Server name sa DataBase
        SqlConnection sqlConnection;

        public SqlDbData()
        {
            sqlConnection = new SqlConnection(connectionString);
        }

        public List<User> GetUsers()
        {
            string selectStatement = "SELECT * FROM Users";

            SqlCommand selectCommand = new SqlCommand(selectStatement, sqlConnection);

            sqlConnection.Open();
            List<User> users = new List<User>();

            SqlDataReader reader = selectCommand.ExecuteReader();

            while (reader.Read())
            {
                string studno = reader["StudNo"].ToString();
                string email = reader["Email"].ToString();
                string password = reader["Password"].ToString();
                string profile = reader["Profile"].ToString();
                DateTime dateUpdated = (DateTime)reader["DateUpdated"];
                DateTime dateVerified = (DateTime)reader["DateVerified"];
                int status = Convert.ToInt32(reader["Status"]);


                User readUser = new User();
                readUser.studno = studno;
                readUser.email = email;
                readUser.password = password;
                readUser.dateUpdated = dateUpdated;
                readUser.dateVerified = dateVerified;
                readUser.status = status;



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