using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TestProyectBackEnd.DataBase;
using TestProyectBackEnd.Models;

namespace TestProyectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ProductsController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("addToCart")]
        public Response addToCart(Cart cart)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.addToCart(cart, connection);
            return response;
        }
        [HttpPost]
        [Route("placeOrder")]
        public Response placeOrder(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.placeOrder(user, connection);
            return response;
        }
        [HttpPost]
        [Route("OrderList")]
        public Response OrderList(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.OrderList(user, connection);
            return response;
        }
    }
}
