namespace blog_app.Models;
public record News
{
    public string Title { get; set; }
    public string Link { get; set; }
    public string PublishDate { get; set; }
}

