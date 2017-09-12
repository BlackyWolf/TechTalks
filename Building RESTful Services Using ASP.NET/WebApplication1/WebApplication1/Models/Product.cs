namespace WebApplication1.Models
{
    public class Product
    {
        public int Id { get; set; }
        
        public bool Available { get; set; }
        
        public string Name { get; set; }

        public int NumberInStock { get; set; }

        public decimal Price { get; set; }
    }
}