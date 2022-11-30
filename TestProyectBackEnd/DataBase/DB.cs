using System.Data.SqlClient;
using TestProyectBackEnd.Models;
using System.Data;

namespace TestProyectBackEnd.DataBase
{
    public class DB
    {
        public Response register(Users users,SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand command = new SqlCommand("sp_register",connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@FirstName", users.FirstName);
            command.Parameters.AddWithValue("@LastName", users.LastName);
            command.Parameters.AddWithValue("@Password", users.Password);
            command.Parameters.AddWithValue("@Email", users.Email);
            command.Parameters.AddWithValue("@Fund", 0);
            command.Parameters.AddWithValue("@Type", "Users");
            command.Parameters.AddWithValue("@Status", "Pending");
            connection.Open();
            int i = command.ExecuteNonQuery();
            connection.Close();
            if (i>0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "User registered successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User registration failed";
            }
            return response;
        }
    }
}
