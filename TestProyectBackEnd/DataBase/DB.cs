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
        public Response Login(Users users, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_login",connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@Email",users.Email);
            adapter.SelectCommand.Parameters.AddWithValue("@Password", users.Password);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                response.StatusCode=200;
                response.StatusMessage = "User is valid";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User is invalid";
                response.user = null;
            }
            return response;
        }
        public Response viewUser(Users users, SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter("sp_viewUser", connection);
            adapter.SelectCommand.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            Response response = new Response();
            Users user = new Users();
            if (dt.Rows.Count > 0)
            {
                user.ID = Convert.ToInt32(dt.Rows[0]["ID"]);
                user.FirstName = Convert.ToString(dt.Rows[0]["FirstName"]);
                user.LastName = Convert.ToString(dt.Rows[0]["LastName"]);
                user.Email = Convert.ToString(dt.Rows[0]["Email"]);
                user.Type = Convert.ToString(dt.Rows[0]["Type"]);
                user.Fund = Convert.ToDecimal(dt.Rows[0]["Fund"]);
                user.CreatedOn = Convert.ToDateTime(dt.Rows[0]["CreatedOn"]);
                user.Password = Convert.ToString(dt.Rows[0]["Password"]);
                response.StatusCode = 200;
                response.StatusMessage = "User exists";
                response.user = user;
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User does not exists";
                response.user = null;
            }
            return response;
        }
        public Response updateProfile(Users users, SqlConnection connection)
        {
           Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_updateProfile",connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@FirstName",users.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", users.LastName);
            sqlCommand.Parameters.AddWithValue("@Password", users.Password);
            sqlCommand.Parameters.AddWithValue("@Email", users.Email);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Record update successfully";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Some error occured. Try sfter sometime";
            }
            return response;
        }
        public Response addToCart(Cart cart, SqlConnection connection)
        {
            Response response =new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_AddToCart", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@UserId", cart.UserId);
            sqlCommand.Parameters.AddWithValue("@ProductId", cart.ProductId);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", cart.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Discount", cart.Discount);
            sqlCommand.Parameters.AddWithValue("@Quantity", cart.Quantity);
            sqlCommand.Parameters.AddWithValue("@TotalPrice", cart.TotalPrice);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode=200;
                response.StatusMessage = "Item added successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Item could not bu added";
            }
            return response;
        }
        public Response placeOrder(Users users, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_placeOrder", connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@ID", users.ID);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if (i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Order has been placed successfully";

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order could not be placed";
            }
            return response;
        }
        public Response OrderList(Users users, SqlConnection connection)
        {
            Response response = new Response();
            List<Orders> listOrders = new List<Orders>();
            SqlDataAdapter sqlCommand = new SqlDataAdapter("sp_OrderList", connection);
            sqlCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.SelectCommand.Parameters.AddWithValue("@ID", users.ID);
            sqlCommand.SelectCommand.Parameters.AddWithValue("@Type", users.Type);
            DataTable dt = new DataTable();
            sqlCommand.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Orders order = new Orders();
                    order.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    order.OrderNo = Convert.ToString(dt.Rows[i]["OrderNo"]);
                    order.OrderTotal = Convert.ToDecimal(dt.Rows[i]["OrderTotal"]);
                    order.OrderStatus = Convert.ToString(dt.Rows[i]["OrderStatus"]);
                    listOrders.Add(order);
                }
                if(listOrders.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "Order details fetched";
                    response.listOrders = listOrders;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "Order details are not available";
                    response.listOrders = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Order details are not available";
                response.listOrders = null;
            }
            return response;
        }
        public Response AddUpdateProducts(Products product, SqlConnection connection)
        {
            Response response = new Response();
            SqlCommand sqlCommand = new SqlCommand("sp_AddUpdateProducts",connection);
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.Parameters.AddWithValue("@Name", product.Name);
            sqlCommand.Parameters.AddWithValue("@ManuFacturer", product.ManuFacturer);
            sqlCommand.Parameters.AddWithValue("@UnitPrice", product.UnitPrice);
            sqlCommand.Parameters.AddWithValue("@Discount", product.Discount);
            sqlCommand.Parameters.AddWithValue("@Quantity", product.Quantity);
            sqlCommand.Parameters.AddWithValue("@ExpDate", product.ExpDate);
            sqlCommand.Parameters.AddWithValue("@ImageURL", product.ImageURL);
            sqlCommand.Parameters.AddWithValue("@Status", product.Status);
            sqlCommand.Parameters.AddWithValue("@Type", product.Type);
            connection.Open();
            int i = sqlCommand.ExecuteNonQuery();
            connection.Close();
            if(i > 0)
            {
                response.StatusCode = 200;
                response.StatusMessage = "Product inserted successfully";
            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "Product did not save. Try again";
            }
            return response;
        }
        public Response userList(SqlConnection connection)
        {
            Response response = new Response();
            List<Users> listUsers = new List<Users>();
            SqlDataAdapter sqlCommand = new SqlDataAdapter("sp_userList", connection);
            sqlCommand.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            sqlCommand.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Users user = new Users();
                    user.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    user.FirstName = Convert.ToString(dt.Rows[i]["FirstName"]);
                    user.LastName = Convert.ToString(dt.Rows[i]["LastName"]);
                    user.Password = Convert.ToString(dt.Rows[i]["Password"]);
                    user.Email = Convert.ToString(dt.Rows[i]["Email"]);
                    user.Fund = Convert.ToDecimal(dt.Rows[i]["Fund"]);
                    user.Type = Convert.ToString(dt.Rows[i]["Type"]);
                    user.Status = Convert.ToInt32(dt.Rows[i]["Status"]);
                    user.CreatedOn = Convert.ToDateTime(dt.Rows[i]["CreatedOn"]);

                    listUsers.Add(users);
                }
                if (listUsers.Count > 0)
                {
                    response.StatusCode = 200;
                    response.StatusMessage = "User details fetched";
                    response.listUsers = listUsers;
                }
                else
                {
                    response.StatusCode = 100;
                    response.StatusMessage = "User details are not available";
                    response.listUsers = null;
                }

            }
            else
            {
                response.StatusCode = 100;
                response.StatusMessage = "User details are not available";
                response.listUsers = null;
            }
            return response;
        }
    }
}
