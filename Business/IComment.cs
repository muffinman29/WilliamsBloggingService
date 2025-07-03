namespace Business
{
    public interface IComment
    {
        public Task<Data.Models.Comment> GetCommentById(int commentId);
        public Task<List<Data.Models.Comment>> GetComments();
        public Task<string> DeleteComment(Data.Models.Comment comment);
        public Task<string> UpdateComment(Data.Models.Comment comment);
        public Task<string> CreateComment(Data.Models.Comment comment);
        public Task<List<Data.Models.Comment>> GetCommentsByBlogId(int id);
    }
}
