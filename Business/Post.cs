using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Business
{
    public class Post : IPost
    {
        private readonly BloggingContext db = new BloggingContext();

        public Post()
        {
            
        }

        public async Task<Data.Models.Post> GetPost(int postId)
        {
            try
            {
                return await db.Posts.FindAsync(postId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> DeletePost(Data.Models.Post post) {
            try
            {
                db.Remove(post);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> UpdatePost(Data.Models.Post post)
        {
            try
            {
                db.Update(post);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> CreatePost(Data.Models.Post post)
        {
            try
            {
                db.Add(post);
                await db.SaveChangesAsync();
                return "success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<Data.Models.Post>> GetPostsByBlogId(int blogId)
        {
            var allPosts = new List<Data.Models.Post>();
            try
            {
                allPosts = await db.Posts.Where(blog => blog.BlogId == blogId).ToListAsync();
            }
            catch (Exception)
            {

                throw;
            }

            return allPosts;
        }
    }
}
