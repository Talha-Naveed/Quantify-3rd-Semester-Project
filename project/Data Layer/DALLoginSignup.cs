using project.Business_Layer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Data_Layer
{
    internal static class DALLoginSignup
    {
        
        public static bool InsertSignUpDetailsInDataBase(User user)
        {
                                   
            //string insertQuery = "INSERT INTO USERS ([First Name], [Last Name], Email, Password) VALUES ('" + user.FirstName + "', '" + user.LastName + "', '" + user.Email + "', '" + user.Password + "');";
            string insertQuery = "INSERT INTO USERS ([First Name], [Last Name], Email, [User Password]) VALUES (@FirstName, @LastName, @Email, @Password)";
            SqlCommand command = new SqlCommand(insertQuery, Connection.GetConnection());
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);
            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected > 0;

        }
        public static bool ValidateLogin(User user)
        {
            string selectQuery = "SELECT COUNT(*) FROM USERS WHERE Email = @Email AND [User Password] = @Password";

            SqlCommand command = new SqlCommand(selectQuery, Connection.GetConnection());
            command.Parameters.AddWithValue("@Email", user.Email);
            command.Parameters.AddWithValue("@Password", user.Password);

            object result = command.ExecuteScalar();
            if (result != null && int.TryParse(result.ToString(), out int rowCount))
            {
                return rowCount == 1;
            }
            return false;
        }

    }
}
