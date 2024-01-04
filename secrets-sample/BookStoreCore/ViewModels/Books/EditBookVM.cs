using BookStoreCore.Models;

namespace BookStoreCore.ViewModels.Books
{
    public class EditBookVM
    {
        public Book Book { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Publisher> Publishers { get; set; }
        //public int BookId { get; set; }
        //public string Title { get; set; }
        //public string Author { get; set; }
        //public int PublisherId { get; set; }
        //public int CategoryId { get; set; }
    }
}
