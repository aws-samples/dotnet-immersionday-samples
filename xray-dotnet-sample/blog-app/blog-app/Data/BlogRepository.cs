using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace blog_app.Models
{
    public class BlogRepository : IBlogRepository
    {
        private BlogDbContext _blogDbContext;
        private SqlHelper _sqlHelper;
        private string _connString;
        private IConfiguration _configuration;
        public BlogRepository(BlogDbContext blogDbContext, IConfiguration config)
        {
            _configuration = config;
            _blogDbContext = blogDbContext;
            _connString = _configuration["SQLConnectionString"];
        }

        public List<BlogCategory> GetBlogCategories()
        {
            _sqlHelper = new SqlHelper(_connString);
            DataTable dt = _sqlHelper.GetDataTable("select * from BlogCategory");
            List<BlogCategory> categories = new List<BlogCategory>();
            foreach (DataRow row in dt.Rows)
            {
                var cat = new BlogCategory { Id = (int)row.ItemArray[0], Name = row.ItemArray[1].ToString() };
                categories.Add(cat);
            }
            return categories;
            //return _blogDbContext.Categories.ToList<BlogCategory>();
        }

        public List<BlogPost> GetBlogPosts()
        {
            return _blogDbContext.Posts.ToList<BlogPost>(); ;
        }

        public BlogPost GetBlogPost(int id)
        {
            return (from post in _blogDbContext.Posts.ToList<BlogPost>() where post.Id == id select post).First();
        }
    }
}
