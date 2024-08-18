using System.ComponentModel.DataAnnotations;

namespace WebAPIDemo.Models
{
    public class AddProductRequest
    {
        [Required]
        public string Description { get; set; } = string.Empty;
        [Required]
        public decimal Price { get; set; }
    }
}
