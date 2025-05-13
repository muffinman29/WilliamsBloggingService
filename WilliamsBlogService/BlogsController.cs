using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        public BlogsController()
        {
            
        }

        [HttpGet("all")]
        public async Task<List<Data.Models.Blog>> GetAllBlogs()
        {
            try
            {
                var blogInstance = new Business.Blog();
                return await blogInstance.GetAllBlogs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Data.Models.Blog> GetBlog(int id)
        {
            try
            {
                var blogInstance = new Business.Blog();
                return await blogInstance.GetBlog(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<string> CreateBlog(Data.Models.Blog Blog)
        {
            try
            {
                var blogInstance = new Business.Blog();
                await blogInstance.CreateBlog(Blog);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<string> UpdateBlog(Data.Models.Blog Blog)
        {
            try
            {
                var blogInstance = new Business.Blog();
                await blogInstance.UpdateBlog(Blog);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteBlog(Data.Models.Blog blog)
        {
            try
            {
                var blogInstance = new Business.Blog();
                await blogInstance.DeleteBlog(blog);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
