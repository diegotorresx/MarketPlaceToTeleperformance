using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TestProyectBackEnd.DataBase;
using TestProyectBackEnd.Models;

namespace TestProyectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public AdminController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("AddUpdateProducts")]
        public Response AddUpdateProducts(Products product)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.AddUpdateProducts(product, connection);
            return response;
        }

        [HttpGet]
        [Route("userList")]
        public Response userList(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.userList(user,connection);
            return response;
        }
    }
}
