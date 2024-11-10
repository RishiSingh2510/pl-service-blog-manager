using blog_management_service.Models;
namespace blog_management_service.Interfaces
{
    public interface IBlogPostService
    {
        BlogPost CreatePost(BlogPost blogPost);
        BlogPost? GetPostById(int id);
        List<BlogPost> GetAllPost();
        BlogPost UpdatePost(int id, BlogPost blogPost);
        bool DeletePost(int id);
    }
}
