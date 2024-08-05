using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;

namespace ProductsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //[controller] -> bu kullanım direkt olarak controller ismini key değeri olarak verir.
    //Buraya api/products da yazabilirdik ikisi de aynı şey fakat dinamik hale getirmek için ilk kullanım daha doğru olur.
    public class ProductsController : ControllerBase //Api COntroller oluşturduğumuzda Viewlerle çalışmayacağımız için ControllerBase kullanmalıyız
    {
        private readonly DatabaseContext _context;

        public ProductsController(DatabaseContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            if (_context == null)
            {
                return NotFound();
            }
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProduct(int? id)
        {
            if (id == null)
            {
                return NotFound(); //Bu kullanım yerine özelleştirilmiş kullanım için StatusCode(404, "bulunamadı") gibi bir değer de yazılabilir.
            }

            var p = _context?.Products.FirstOrDefault(i => i.id == id);
            if (p == null)
            {
                return NotFound();
            }
            return Ok(p);
        }
    }
}