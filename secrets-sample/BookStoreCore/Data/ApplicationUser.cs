using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace BookStoreCore.Data
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(255)]
        [PersonalData]
        public string FirstName { get; set; }
        [MaxLength(255)]
        [PersonalData]
        public string LastName { get; set; }
    }
}
