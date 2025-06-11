using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WilliamsBlogService
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        public PostsController() { }
       
        [HttpGet("{id}")]
        public async Task<Data.Models.Post> GetPostById(int id)
        {
            try
            {
                var post = new Business.Post();
                return await post.GetPost(id);
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
                var post = new Business.Post();
                return await post.GetPostsByBlogId(id);
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
                var postInstance = new Business.Post();
                await postInstance.CreatePost(post);
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
                var postInstance = new Business.Post();
                await postInstance.UpdatePost(post);
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
                var postInstance = new Business.Post();
                await postInstance.DeletePost(post);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
