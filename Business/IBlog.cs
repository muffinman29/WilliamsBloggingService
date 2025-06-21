using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IBlog
    {
        public Task<Data.Models.Blog> GetBlogById(int blogId);
        public Task<List<Data.Models.Blog>> GetBlogs();
        public Task<string> DeleteBlog(Data.Models.Blog blog);
        public Task<string> UpdateBlog(Data.Models.Blog blog);
        public Task<string> CreateBlog(Data.Models.Blog blog);
        public Task<List<Data.Models.Blog>> GetBlogByUserId(int id);

    }
}
