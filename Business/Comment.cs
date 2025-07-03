using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Comment : IComment
    {
        private readonly BloggingContext db = new BloggingContext();
        public async Task<string> CreateComment(Data.Models.Comment comment)
        {
            try
            {
                db.Add(comment);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeleteComment(Data.Models.Comment comment)
        {
            try
            {
                db.Remove(comment);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<Data.Models.Comment> GetCommentById(int commentId)
        {
            try
            {
                return await db.Comments.FindAsync(commentId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Data.Models.Comment>> GetComments()
        {
            try
            {
                return await db.Comments.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Data.Models.Comment>> GetCommentsByBlogId(int id)
        {
            try
            {
                return await db.Comments.Where(x => x.BlogId == id).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> UpdateComment(Data.Models.Comment comment)
        {
            try
            {
                db.Update(comment);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
