using System;
using System.ComponentModel.DataAnnotations;
namespace AspNetCoreTodo.Models
{
    public class URLRedirect
    {
        [KeyAttribute]
        public string Id { get; set; }
        public string UserId { get; set; }
        [Required]
        public string DestinationUrl { get; set; }
        public long NumVisits { get; set; }
    }
}
