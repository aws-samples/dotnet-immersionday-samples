using System.ComponentModel.DataAnnotations;

namespace BookStoreCore.Models
{
    public class Publisher
   {
        [Key]
        public int PublisherId { get; set; }
        public string PublisherName { get; set; }

        public List<Book>? Book { get; set; }
    }
}
