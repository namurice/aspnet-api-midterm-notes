using System.ComponentModel.DataAnnotations;

namespace midterm.Models
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int AuthorId { get; set; }
        public int Upvotes { get; set; } = 0;
        public int Downvotes { get; set; } = 0;
        public DateTime CreateAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = null;
    }
}