using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using blog_app.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Xml.Linq;
using blog_app.Data;
using Microsoft.Extensions.Configuration;

namespace blog_app.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private IBlogRepository _blogRepository;
        private IHttpContextAccessor _accessor;
        private DDBHelper _ddbHelper;
        private IConfiguration _configuration;
        private AWSHelper _AWSHelper;

        public List<BlogCategory> Categories { get; set; }
        public List<BlogPost> Posts { get; set; }
        public string ClientIP { get; set; }

        public List<News> News { get; set; }

        public byte[] Image { get; set; }
        public IndexModel(ILogger<IndexModel> logger , IBlogRepository blogRepository , IHttpContextAccessor accessor, IConfiguration configuration)
        {
            _logger = logger;
            _blogRepository = blogRepository;
            _accessor = accessor;
            _configuration = configuration;

            Categories = _blogRepository.GetBlogCategories();
            Posts = _blogRepository.GetBlogPosts();
            Image = LoadAdRotaor();
            ClientIP = GetClientIP();
            News = GetAWSNews();
        }


        private byte[] LoadAdRotaor()
        {
            byte[] imageBinary = null;
            string image =  Environment.CurrentDirectory + "/wwwroot/images/ad/AWS.png";
            imageBinary = System.IO.File.ReadAllBytes(image);
            return imageBinary;
        }
        public void OnGet()
        {

        }

        private string GetClientIP()
        {

            return _accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }

        private List<News> GetAWSNews()
        {
            string rssFeedUrl = "http://feeds.feedburner.com/AmazonWebServicesBlog";
            List<News> feeds = new List<News>();
            XDocument xDoc = XDocument.Load(rssFeedUrl);
            var items = (from x in xDoc.Descendants("item")
                         select new
                         {
                            Title = x.Element("title").Value,
                            Link = x.Element("link").Value,
                            Pubdate = x.Element("pubDate").Value,                           
                         });

            if (items != null)
            {
                feeds.AddRange(items.Select(i => new News
                {
                    Title = i.Title,
                    Link = i.Link,
                    PublishDate = i.Pubdate,                    
                }));
            }

            return feeds;
        }

      
    }
}
