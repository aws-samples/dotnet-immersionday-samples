using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BookStoreCore.Data;
using BookStoreCore.Models;

namespace BookStoreCore.Pages.Books
{
    public class DeleteModel : PageModel
    {
        private readonly BookStoreCore.Data.ApplicationDbContext _context;
        private readonly ILogger _logger;
        public DeleteModel(BookStoreCore.Data.ApplicationDbContext context, ILogger<DeleteModel> logger)
        {
            _context = context;
            _logger = logger;
        }

        [BindProperty]
      public Book Book { get; set; }
        public string ErrorMessage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .AsNoTracking()
                .Include(b => b.Category)
                .Include(b => b.Publisher)
                .FirstOrDefaultAsync(m => m.BookId == id);


            if (book == null)
            {
                return NotFound();
            }
            
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMessage = String.Format("Delete {ID} failed. Try again", id);
            }

            else 
            {
                Book = book;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            try
            {
                Book = book;
                _context.Books.Remove(Book);
                await _context.SaveChangesAsync();
            }
            catch(DbUpdateException ex)
            {
                _logger.LogError(ex, ErrorMessage);
            }

            return RedirectToPage("./Index");
        }
    }
}
