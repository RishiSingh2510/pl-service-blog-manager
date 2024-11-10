using blog_management_service.Interfaces;
using blog_management_service.Models;
using Microsoft.AspNetCore.Mvc;

namespace blog_management_service.Controllers
{
    /// <summary>
    /// Controller for managing blog posts.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BlogPostController : ControllerBase
    {
        private readonly IBlogPostService _blogPostService;

        /// <summary>
        /// Initializes a new instance of the <see cref="BlogPostController"/> class.
        /// </summary>
        /// <param name="blogPostService">The blog post service.</param>
        public BlogPostController(IBlogPostService blogPostService)
        {
            _blogPostService = blogPostService;
        }

        /// <summary>
        /// Creates a new blog post.
        /// </summary>
        /// <param name="blogPost">The blog post to create.</param>
        /// <returns>The created blog post.</returns>
        [HttpPost]
        public IActionResult CreateBlogPost([FromBody] BlogPost blogPost)
        {
            try
            {
                var post = _blogPostService.CreatePost(blogPost);
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAllBlogPosts()
        {
            try
            {
                var posts = _blogPostService.GetAllPost();
                return Ok(posts);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Gets a specific blog post by ID.
        /// </summary>
        /// <param name="id">The ID of the blog post.</param>
        /// <returns>The blog post with the specified ID.</returns>
        [HttpGet("{id}")]
        public IActionResult GetBlogPost(int id)
        {
            try
            {
                var post = _blogPostService.GetPostById(id);
                if (post == null)
                {
                    return NotFound($"No Post found.");
                }
                return Ok(post);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Updates an existing blog post.
        /// </summary>
        /// <param name="id">The ID of the blog post to update.</param>
        /// <param name="updatedBlogPost">The updated blog post.</param>
        /// <returns>An IActionResult indicating the success of the update operation.</returns>
        [HttpPut("{id}")]
        public IActionResult UpdateBlogPost(int id, [FromBody] BlogPost updatedBlogPost)
        {
            try
            {
                var updatedPost = _blogPostService.UpdatePost(id, updatedBlogPost);
                if (updatedPost == null)
                {
                    return NotFound($"Blog Post not found. {id}");
                }
                else
                {
                    return Ok(updatedPost);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        /// <summary>
        /// Deletes a blog post by ID.
        /// </summary>
        /// <param name="id">The ID of the blog post to delete.</param>
        /// <returns>An IActionResult indicating the success of the delete operation.</returns>
        [HttpDelete("{id}")]
        public IActionResult DeleteBlogPost(int id)
        {
            try
            {
                return _blogPostService.DeletePost(id) ? Ok() : NotFound($"Blog Post not found. {id}");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
