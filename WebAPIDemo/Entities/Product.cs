namespace WebAPIDemo.Entities
{
    public class Product
    {
        public int ID { get; set; }
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public DateTime Modified { get; set; }
    }
}
