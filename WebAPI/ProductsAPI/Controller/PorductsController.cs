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

        [HttpPost]
        public async Task<IActionResult> AddProduct(Product product)
        {
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetProduct), new { id = product.id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, Product product)
        {
            if (id != product.id)
            {
                return BadRequest();
            }

            var p = await _context.Products.FirstOrDefaultAsync(i => i.id == id);

            if (p == null)
            {
                return NotFound();
            }
            else
            {
                p.ProductName = product.ProductName;
                p.Price = product.Price;
                p.IsActive = product.IsActive;

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return NoContent();
            }
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var p = await _context.Products.FirstOrDefaultAsync(i => i.id == id);
            if (p == null)
            {
                return NotFound();
            }
            _context.Products.Remove(p);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}