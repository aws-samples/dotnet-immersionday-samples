using System.Collections.Generic;

namespace blog_app.Models
{
    public interface IBlogRepository
    {
        List<BlogPost> GetBlogPosts();
        BlogPost GetBlogPost(int id);
        List<BlogCategory> GetBlogCategories();
    }
}
