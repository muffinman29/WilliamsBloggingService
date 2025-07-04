using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Blog : IBlog
    {
        private readonly BloggingContext db = new BloggingContext();

        public Blog()
        {

        }

        public async Task<Data.Models.Blog> GetBlogById(int blogId)
        {
            try
            {
                return await db.Blogs.FindAsync(blogId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Data.Models.Blog>> GetBlogs()
        {
            try
            {
                return await db.Blogs.ToListAsync();
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
                db.Remove(blog);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdateBlog(Data.Models.Blog blog)
        {
            try
            {
                db.Update(blog);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> CreateBlog(Data.Models.Blog blog)
        {
            try
            {
                db.Add(blog);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Data.Models.Blog>> GetBlogByUserId(int id)
        {
            try
            {
                return await db.Blogs.Where(x => x.UserId == id).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
