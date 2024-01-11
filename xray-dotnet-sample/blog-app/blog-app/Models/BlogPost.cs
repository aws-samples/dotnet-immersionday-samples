namespace blog_app.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public BlogCategory Category { get; set; }
    }
}
