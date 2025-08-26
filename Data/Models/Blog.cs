using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public required string Url { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Author { get; set; }
        public List<Post> Posts { get; } = [];

        [ForeignKey("User")]
        public int UserId { get; set; }
    }
}
