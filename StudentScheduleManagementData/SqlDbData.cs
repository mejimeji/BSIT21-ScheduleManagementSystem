using StudentScheduleManagementModel;
using System.Data.SqlClient;

namespace StudentScheduleManagementData
{
    public class SqlDbData
    {

        string connectionString
            //= "Server=tcp:20.2.66.4,1433;Database=ScheduleManagementSystemdb;User Id=sa;Password=!Root123";
        ="Server=localhost\\SQLEXPRESS;Database=ScheduleManagementSystemdb;Trusted_Connection=True;";
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

        public int AddUser(string studno, string email, string password)
        {
            int success;

            
            string insertStatement = "INSERT INTO Users (StudNo, Email, Password, DateUpdated, DateVerified, Status) " +
                                     "VALUES (@StudNo, @Email, @Password, @DateUpdated, @DateVerified, @Status)";

            SqlCommand insertCommand = new SqlCommand(insertStatement, sqlConnection);

            
            insertCommand.Parameters.AddWithValue("@StudNo", studno);
            insertCommand.Parameters.AddWithValue("@Email", email);
            insertCommand.Parameters.AddWithValue("@Password", password);
            insertCommand.Parameters.AddWithValue("@DateUpdated", DateTime.Now);       
            insertCommand.Parameters.AddWithValue("@DateVerified", DateTime.Now);      
            insertCommand.Parameters.AddWithValue("@Status", 1);                       

            try
            {
                sqlConnection.Open();
                success = insertCommand.ExecuteNonQuery(); 
            }
            finally
            {
                sqlConnection.Close(); 
            }

            return success; 
        }

        public int UpdateUser(string email, int status)
        {
            int success;

           
            string updateStatement = "UPDATE users SET status = @Status WHERE email = @Email";

            using (SqlCommand updateCommand = new SqlCommand(updateStatement, sqlConnection))
            {
                sqlConnection.Open();

             
                updateCommand.Parameters.AddWithValue("@Email", email);
                updateCommand.Parameters.AddWithValue("@Status", status);

                success = updateCommand.ExecuteNonQuery();
            }

            sqlConnection.Close();

            return success;
        }

        public int DeleteUser(string studno)
        {
            int success;

            string deleteStatement = $"DELETE FROM users WHERE StudNo = @StudNo";
            SqlCommand deleteCommand = new SqlCommand(deleteStatement, sqlConnection);
            sqlConnection.Open();

            deleteCommand.Parameters.AddWithValue("@StudNo", studno);

            success = deleteCommand.ExecuteNonQuery();

            sqlConnection.Close();

            return success;
        }
    }
}