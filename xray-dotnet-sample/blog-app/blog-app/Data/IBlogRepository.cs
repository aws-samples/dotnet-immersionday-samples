using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_app.Models
{
    public interface IBlogRepository
    {
        List<BlogPost> GetBlogPosts();
        BlogPost GetBlogPost(int id);
        List<BlogCategory> GetBlogCategories();
    }
}
