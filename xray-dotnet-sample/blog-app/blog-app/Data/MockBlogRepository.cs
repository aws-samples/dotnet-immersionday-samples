using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace blog_app.Models
{
    public class MockBlogRepository : IBlogRepository
    {
        private List<BlogCategory> _blogCategories;
        private List<BlogPost> _blogPosts;

        public MockBlogRepository()
        {
            GenerateBlogCategories();
            GenerateBlogPost();
        }

        

        public List<BlogCategory> GetBlogCategories()
        {
            return _blogCategories;
        }

        public List<BlogPost> GetBlogPosts()
        {
            return _blogPosts;
        }

        public BlogPost GetBlogPost(int id)
        {
            return  (from post in _blogPosts where post.Id == id select post).First();
        }

        private void GenerateBlogPost()
        {
            _blogPosts = new List<BlogPost>
            {
                new BlogPost{ Id=1,Title = "Getting Started with EC2", Category = new BlogCategory{ Id=1, Name="EC2"} ,  Content= "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p><p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>"},
                new BlogPost{ Id=2,Title = "Host static website using S3", Category = new BlogCategory{ Id=1, Name="EC2"} ,  Content= "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p><p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>"}
            };
        }

        private void GenerateBlogCategories()
        {
            _blogCategories = new List<BlogCategory>
            {
                new BlogCategory{ Id = 1, Name = "AWS"},
                new BlogCategory{ Id = 1, Name = "EC2"},
                new BlogCategory{ Id = 1, Name = "S3"},
                new BlogCategory{ Id = 1, Name = "EMR"},
            };
        }
    }
}
