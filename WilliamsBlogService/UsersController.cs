using Microsoft.AspNetCore.Mvc;

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
        public async Task<string> RegisterUser(Data.Models.User User)
        {
            try
            {
                var userInstance = new Business.User();
                await userInstance.CreateUser(User);
                return "success";
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

        [HttpPost("authenticate")]
        public async Task<Data.Models.User> Authenticate([FromBody]Data.Models.User currentUser)
        {
            try
            {
                var userInstance = new Business.User();
                return await userInstance.AuthenticateUser(currentUser.Username, currentUser.Password);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
