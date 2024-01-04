using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookStoreCore.Data;
using BookStoreCore.Models;
using BookStoreCore.ViewModels.Books;
using System.Security.Policy;

namespace BookStoreCore.Pages.Books
{
    public class EditModel : PageModel
    {
        private readonly BookStoreCore.Data.ApplicationDbContext _context;

        public EditModel(BookStoreCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Book Book { get; set; } = default!;

        //[BindProperty]
        //public EditBookVM BookVM { get; set; } = default!;
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Books == null)
            {
                return NotFound();
            }

          //Includes relational data to book
            var book =  await _context.Books
                .Include(b => b.Publisher)
                .Include(b => b.Category)
                .FirstOrDefaultAsync(m => m.BookId == id);


            if (book == null)
            {
                return NotFound();
            }

            //Reads in DropDown Lists for Relational Data.
            ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
            ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            Book = book;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var bookToUpdate = await _context.Books.FindAsync(id);

            if (!BookExists(id))
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Book>(
                bookToUpdate,
                "book",
                b => b.Title, b => b.Author, b => b.CategoryId, b => b.PublisherId))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool BookExists(int id)
        {
          return _context.Books.Any(e => e.BookId == id);
        }
    }
}
