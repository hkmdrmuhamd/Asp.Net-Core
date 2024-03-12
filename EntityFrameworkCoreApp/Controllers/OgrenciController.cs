using EntityFrameworkApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreApp.Controllers
{
    public class OgrenciController: Controller
    {
        private readonly DataContext _context;

        public OgrenciController(DataContext context) //OgrenciController constructor'u 
        {
            _context = context; //Bu kullanım ile DataContext sınıfına ait tüm entity'lere erşim sağlayabiliriz.
        }

        public async Task<IActionResult> Index()
        {
            var ogrenciler = await _context.Ogrenciler.ToListAsync();
            return View(ogrenciler);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Create(Ogrenci model) //Database işlemleri genellikle async (asenkron) olur
        {
            _context.Add(model);
            await _context.SaveChangesAsync(); //Yapılan değişikler asenkron olarak yapılır ve kaydedilir
            return RedirectToAction("Index");
        }
    }
}
