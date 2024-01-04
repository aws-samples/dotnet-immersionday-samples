using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BookStoreCore.Data;
using BookStoreCore.Models;
using BookStoreCore.ViewModels.Books;

namespace BookStoreCore.Pages.Books
{
    public class CreateVMModel : PageModel
    {
        private readonly BookStoreCore.Data.ApplicationDbContext _context;

        public CreateVMModel(BookStoreCore.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryId"] = new SelectList(_context.Categories, "CategoryId", "CategoryName");
        ViewData["PublisherId"] = new SelectList(_context.Publishers, "PublisherId", "PublisherName");
            return Page();
        }

        //[BindProperty]
        //public Book Book { get; set; }

        [BindProperty]
        public CreateBookVM CreateBookVM { get; set; }



        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {


            if (!ModelState.IsValid)
            {
                return Page();
            }

            var entry = _context.Add(new Book());
            entry.CurrentValues.SetValues(CreateBookVM);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            //var emptyBook = new Book();

            ////Updates the model only for the fields Specified.
            //if(await TryUpdateModelAsync<Book> (
            //    emptyBook,
            //    "book",
            //    b=> b.Title, b => b.Author))
            //{
            //    _context.Books.Add(emptyBook);
            //     await _context.SaveChangesAsync();
            //    return RedirectToPage("./Index");
            //}

            //return Page();

        }
    }
}
