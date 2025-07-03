namespace Business
{
    public interface IPost
    {
        public Task<Data.Models.Post> GetPost(int postId);

        public Task<string> DeletePost(Data.Models.Post post);
        public Task<string> UpdatePost(Data.Models.Post post);
        public Task<string> CreatePost(Data.Models.Post post);
        public Task<List<Data.Models.Post>> GetPostsByBlogId(int blogId);
    }
}
