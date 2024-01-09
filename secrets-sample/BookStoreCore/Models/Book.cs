using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;

namespace BookStoreCore.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [Required]
        public string Title { get; set; }
        public string Author { get; set; }

        public int PublisherId { get; set; }
        public Publisher? Publisher { get; set; }

        public int CategoryId { get; set; }
        public Category? Category { get; set; }
        
    }
}
