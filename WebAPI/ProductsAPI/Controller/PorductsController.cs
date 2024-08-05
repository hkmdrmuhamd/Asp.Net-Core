using Microsoft.AspNetCore.Mvc;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //[controller] -> bu kullanım direkt olarak controller ismini key değeri olarak verir.
    //Buraya api/products da yazabilirdik ikisi de aynı şey fakat dinamik hale getirmek için ilk kullanım daha doğru olur.
    public class ProductsController : ControllerBase //Api COntroller oluşturduğumuzda Viewlerle çalışmayacağımız için ControllerBase kullanmalıyız
    {
        private static List<Product>? _products;

        public ProductsController()
        {
            _products = new List<Product>
            {
                new() { id = 1, ProductName = "Iphone12", Price = 30000, IsActive = false },
                new() { id = 2, ProductName = "Iphone13", Price = 40000, IsActive = true },
                new() { id = 3, ProductName = "Iphone14", Price = 50000, IsActive = false },
                new() { id = 4, ProductName = "Iphone15", Price = 60000, IsActive = true }
            };
        }

        [HttpGet]
        public List<Product>? GetProducts()
        {
            return _products;
        }

        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _products?.FirstOrDefault(i => i.id == id) ?? new Product(); // eğer değer yoksa yeni boş bir product oluştur.
        }
    }
}