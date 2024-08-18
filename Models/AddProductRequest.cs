namespace WebAPIDemo.Models
{
    public class AddProductRequest
    {
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
    }
}
