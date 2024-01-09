using System.ComponentModel.DataAnnotations;

namespace BookStoreCore.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [MaxLength(100)]
        public string CategoryName { get; set; }

        public ICollection<Book>? Books { get; set; }
    }
}
