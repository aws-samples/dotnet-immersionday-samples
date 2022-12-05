using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace blog_app.Models
{
    public class DbInitializer
    {

        public static void Initialize(BlogDbContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Posts.Any())
            {
                return;   // DB has been seeded
            }

            var posts = new BlogPost[]
            {
            new BlogPost{Title = "Getting Started with EC2", Category = new BlogCategory{  Name="AWS"} ,  Content= "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p><p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>"},
            new BlogPost{Title = "Deploy your first CI/CD pipeline", Category = new BlogCategory{ Name="EC2"} ,  Content= "<p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p><p>Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.</p>"}            
            };
            foreach (BlogPost s in posts)
            {
                context.Posts.Add(s);
            }
            context.SaveChanges();

            var categories = new BlogCategory[]
            {
            new BlogCategory{ Name = "AWS"},
            new BlogCategory{ Name = "EC2"},
            new BlogCategory{ Name = "S3"},
            new BlogCategory{ Name = "SES"},
            };
            foreach (BlogCategory c in categories)
            {
                context.Categories.Add(c);
            }
            context.SaveChanges();            
        }
    }

   
}
