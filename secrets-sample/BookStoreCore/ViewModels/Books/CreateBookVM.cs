namespace BookStoreCore.ViewModels.Books
{
    public class CreateBookVM
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PublisherId { get; set; }
        public int CategoryId { get; set; }
    }
}
