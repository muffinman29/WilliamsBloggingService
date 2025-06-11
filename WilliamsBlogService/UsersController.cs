using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.Net.Http.Headers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WilliamsBlogService
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<Data.Models.User> GetUser(int id)
        {
            try
            {
                var userInstance = new Business.User();
                return await userInstance.GetUser(id);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(Data.Models.User user)
        {
            try
            {
                var userInstance = new Business.User();
                await userInstance.CreateUser(user);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<string> UpdateUser(Data.Models.User user)
        {
            try
            {
                var userInstance = new Business.User();
                await userInstance.UpdateUser(user);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete("{id}")]
        public async Task<string> DeleteUser(int id)
        {
            try
            {
                var userInstance = new Business.User();
                await userInstance.DeleteUser(id);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("token")]
        public async Task<Data.Models.User> GetUserFromToken() {
            try
            {
                var accessToken = await HttpContext.GetTokenAsync(JwtBearerDefaults.AuthenticationScheme, "access_token");
                var user = new Business.User();
                var userTask = user.GetUserFromToken(accessToken ?? "");
                return userTask;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
