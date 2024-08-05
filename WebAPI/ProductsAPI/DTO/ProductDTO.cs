namespace ProductsAPI.DTO
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string ProductName { get; set; } = null!;
        public decimal Price { get; set; }
    }
}