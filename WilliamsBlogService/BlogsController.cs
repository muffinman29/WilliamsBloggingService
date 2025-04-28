using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
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
                var Blog = new Business.Blog();
                return await Blog.GetAllBlogs();
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
                var Blog = new Business.Blog();
                return await Blog.GetBlog(id);
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
                var BlogInstance = new Business.Blog();
                await BlogInstance.CreateBlog(Blog);
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
                var BlogInstance = new Business.Blog();
                await BlogInstance.UpdateBlog(Blog);
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
