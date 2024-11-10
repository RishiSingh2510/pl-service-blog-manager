using System.ComponentModel.DataAnnotations;

namespace blog_management_service.Models
{
    /// <summary>
    /// Represents a blog post.
    /// </summary>
    public class BlogPost
    {
        /// <summary>
        /// Gets or sets the ID of the blog post.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the author of the blog post.
        /// </summary>
        [Required]
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the text content of the blog post.
        /// </summary>
        [Required]
        public string Text { get; set; }

        /// <summary>
        /// Gets or sets the creation date and time of the blog post.
        /// </summary>
        [Required]
        public DateTime CreatedAt { get; set; }
    }
}
