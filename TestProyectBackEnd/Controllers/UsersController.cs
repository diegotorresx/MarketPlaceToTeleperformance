using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using TestProyectBackEnd.DataBase;
using TestProyectBackEnd.Models;

namespace TestProyectBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        [Route("registration")]
        public Response register(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.register(user,connection);
            return response;
        }
        [HttpPost]
        [Route("login")]
        public Response login(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.Login(user, connection);
            return response;
        }
        [HttpPost]
        [Route("viewUser")]
        public Response viewUser(Users user)
        {
            Response response = new Response();
            DB db = new DB();
            SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("Conn").ToString());
            response = db.viewUser(user, connection);
            return response;
        }
    }
}
