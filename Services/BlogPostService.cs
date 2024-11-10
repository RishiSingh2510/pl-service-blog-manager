using blog_management_service.Interfaces;
using blog_management_service.Models;
using blog_management_service.Utils;
namespace blog_management_service.Services
{
    /// <summary>
    /// Service class for managing blog posts.
    /// </summary>
    public class BlogPostService : IBlogPostService
    {
        private List<BlogPost> _blogPosts;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostService"/> class.
        /// </summary>
        public BlogPostService()
        {
            _blogPosts = JsonFileHelper.ReadFromJsonFile<BlogPost>() ?? [];
        }

        /// <summary>
        /// Creates a new blog post.
        /// </summary>
        /// <param name="blogPost">The blog post to create.</param>
        /// <returns>The created blog post.</returns>
        public BlogPost CreatePost(BlogPost blogPost)
        {
            blogPost.Id = AutoIncrementId.GetNextId();
            blogPost.CreatedAt = DateTime.Now;
            _blogPosts.Add(blogPost);
            JsonFileHelper.WriteToJsonFile(_blogPosts);
            return blogPost;
        }

        /// <summary>
        /// Deletes a blog post by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to delete.</param>
        /// <returns>True if the blog post was deleted successfully, otherwise false.</returns>
        public bool DeletePost(int id)
        {
            try
            {
                var removedElementsCount = _blogPosts.RemoveAll(bp => bp.Id == id);
                JsonFileHelper.WriteToJsonFile(_blogPosts);
                return removedElementsCount > 0 ? true : false;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Gets all the blog posts.
        /// </summary>
        /// <returns>A list of all the blog posts.</returns>
        public List<BlogPost> GetAllPost()
        {
            return _blogPosts.ToList();
        }

        /// <summary>
        /// Gets a blog post by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to get.</param>
        /// <returns>The blog post with the specified ID, or null if not found.</returns>
        public BlogPost? GetPostById(int id)
        {
            return _blogPosts.ToList().Find(bp => bp.Id == id);
        }

        /// <summary>
        /// Updates a blog post by its ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to update.</param>
        /// <param name="blogPost">The updated blog post.</param>
        /// <returns>The updated blog post, or null if the blog post was not found.</returns>
        public BlogPost? UpdatePost(int id, BlogPost blogPost)
        {
            var post = GetPostById(id);
            if (post == null)
            {
                return null;
            }
            else
            {
                post.Text = blogPost.Text;
                return post;
            }
        }
    }
}
