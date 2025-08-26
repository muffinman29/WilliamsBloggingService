using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Comment
    {
        public required int Id { get; set; }
        public required string Name { get; set; }
        public required string CommentText { get; set; }

        [ForeignKey("Blog")]
        public int BlogId { get; set; }
    }
}
