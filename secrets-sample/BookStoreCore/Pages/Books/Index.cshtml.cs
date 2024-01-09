using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreCore.Data;
using BookStoreCore.Models;
using System.Diagnostics;

namespace BookStoreCore.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;


        public IndexModel(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _config = configuration;
            MyActivitySource = new ActivitySource(_config.GetSection("Observability")["ServiceName"], _config.GetSection("Observability")["Version"]);
        }

        private static ActivitySource MyActivitySource { get; set; }

        public string NameSort { get; set; }
        //public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }

        public PaginatedList<Book> Books { get; set; }
        //public IList<Book> Books { get;set; } = default!;

        public async Task OnGetAsync(string sortOrder, string searchString, string currentFilter, int? pageIndex)
        {
            //Custom Trace
            using var activity = MyActivitySource.StartActivity("VisitHome", ActivityKind.Server); // this will be translated to a X-Ray Segment
            activity?.SetTag("http.method", "GET");
            activity?.SetTag("http.url", "http://www.bookstorecore.com/Books");
            activity?.SetTag("http.page", "BooksIndex");

            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //DateSort = sortOrder == "Date" ? "date_desc" : "Date";


            //Create Logger to Write in Entries.
            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            IQueryable<Book> booksIQ = from b in _context.Books
                                      select b;
            if (!String.IsNullOrEmpty(searchString))
            {
                booksIQ = booksIQ.Where(b => b.Title.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    booksIQ = booksIQ.OrderByDescending(b => b.Title);
                    break;
                default:
                    booksIQ = booksIQ.OrderBy(b => b.Title);
                    break;
            }

            if (_context.Books != null)
            {
                var pageSize = _config.GetValue("PageSize", 4);
                Books = await PaginatedList<Book>.CreateAsync(booksIQ.AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Publisher), pageIndex ?? 1, pageSize);
            }

        }

        private string GetTraceId()
        {

            ActivitySource activitySource = new ActivitySource("ActivitySourceName", "ActivitySourceVersion");
            var activity = activitySource.StartActivity("ActivityName", ActivityKind.Server); // this will be translated to a X-Ray Segment
            var internalActivity = activitySource.StartActivity("ActivityName", ActivityKind.Internal); // this will be translated to an X-Ray Subsegment


            var traceId = Activity.Current.TraceId.ToHexString();
            var version = "1";
            var epoch = traceId.Substring(0, 8);
            var random = traceId.Substring(8);
            return "{" + "\"traceId\"" + ": " + "\"" + version + "-" + epoch + "-" + random + "\"" + "}";
        }
    }
}
