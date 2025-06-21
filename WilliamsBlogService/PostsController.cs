using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Business;

namespace WilliamsBlogService
{
    [Authorize]
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

        [HttpGet("blog/{id}")]
        public async Task<List<Data.Models.Post>> GetPostsByBlogId(int id)
        {
            try
            {
                return await Post.GetPostsByBlogId(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<string> CreatePost(Data.Models.Post post) {
            try
            {
                await Post.CreatePost(post);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public async Task<string> UpdatePost(Data.Models.Post post) {
            try
            {
                await Post.UpdatePost(post);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete]
        public async Task<string> DeletePost(Data.Models.Post post) {
            try
            {
                await Post.DeletePost(post);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
