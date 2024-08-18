namespace WebAPIDemo.Models
{
    public class ProductResponse
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Modified { get; set; }
    }
}
