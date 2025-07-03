using Business;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WilliamsBlogService
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        IComment Comment { get; set; }
        public CommentsController(IComment comment)
        {
             Comment = comment;
        }
        
        [HttpGet]
        public async Task<List<Data.Models.Comment>> GetComments()
        {
            try
            {
                return await Comment.GetComments();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CommentsController>/5
        [HttpGet("{id}")]
        public async Task<Data.Models.Comment> GetCommentById(int id)
        {
            try
            {
                return await Comment.GetCommentById(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CommentsController>/5
        [HttpGet("blog/{id}")]
        public async Task<List<Data.Models.Comment>> GetCommentByBlogId(int id)
        {
            try
            {
                return await Comment.GetCommentsByBlogId(id);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<CommentsController>
        [HttpPost("create")]
        public async Task<IActionResult> CreateComment([FromBody] Data.Models.Comment comment)
        {
            try
            {
                await Comment.CreateComment(comment);
                return Ok(new { Message = "success" });
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<CommentsController>/5
        [HttpPut("{id}")]
        public async Task<string> UpdateComment([FromBody] Data.Models.Comment comment)
        {
            try
            {
                await Comment.UpdateComment(comment);
                return "success";
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<CommentsController>/5
        [HttpDelete("{id}")]
        public async Task<string> DeleteComment(Data.Models.Comment comment)
        {
            try
            {
                await Comment.DeleteComment(comment);
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
