using System.ComponentModel.DataAnnotations;

namespace Bookstore.Core.Models
{
    public class Author
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
