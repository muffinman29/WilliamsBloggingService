using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        IBlog Blog { get; set; }
        public BlogsController(IBlog blog)
        {
            Blog = blog;
        }

        [HttpGet("all")]
        public async Task<List<Data.Models.Blog>> GetAllBlogs()
        {
            try
            {
                return await Blog.GetBlogs();
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("{id}")]
        public async Task<Data.Models.Blog> GetBlogById(int id)
        {
            try
            {
                return await Blog.GetBlogById(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("user/{id}")]
        public async Task<List<Data.Models.Blog>> GetBlogsByUserId(int id)
        {
            try
            {
                return await Blog.GetBlogByUserId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateBlog(Data.Models.Blog blog)
        {
            try
            {
                await Blog.CreateBlog(blog);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPut]
        public async Task<string> UpdateBlog(Data.Models.Blog blog)
        {
            try
            {
                await Blog.UpdateBlog(blog);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<string> DeleteBlog(Data.Models.Blog blog)
        {
            try
            {
                await Blog.DeleteBlog(blog);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
