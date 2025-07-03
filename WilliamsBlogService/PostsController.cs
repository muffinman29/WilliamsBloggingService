using Business;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public IPost Post { get; set; }
        public PostsController(IPost post)
        {
            Post = post;
        }

        [HttpGet("{id}")]
        public async Task<Data.Models.Post> GetPostById(int id)
        {
            try
            {
                return await Post.GetPost(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpGet("blog/{blogId}")]
        public async Task<List<Data.Models.Post>> GetPostsByBlogId(int blogId)
        {
            try
            {
                return await Post.GetPostsByBlogId(blogId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreatePost(Data.Models.Post post)
        {
            try
            {
                await Post.CreatePost(post);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> UpdatePost(Data.Models.Post post)
        {
            try
            {
                await Post.UpdatePost(post);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<IActionResult> DeletePost(Data.Models.Post post)
        {
            try
            {
                await Post.DeletePost(post);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
