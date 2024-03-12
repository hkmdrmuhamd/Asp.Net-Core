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

        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var ogr = await _context.Ogrenciler.FindAsync(id);
            if(ogr == null)
            {
                return NotFound();
            }
            return View(ogr);
        }

        [HttpPost]
        [ValidateAntiForgeryToken] //Formu açan kişiye özgü üretilen token'ın geçerliliğini kontrol eder ve sadece o token'a sahip kişinin o sayfaya erişimine izin verir.
        public async Task<IActionResult> Edit(int id, Ogrenci model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch(DbUpdateConcurrencyException) //Aynı anda kayıt güncellemesi yapılırken günceleme yapılan kayıdın silindiği durumda oluşabilecek hatalar
                {
                    if(!_context.Ogrenciler.Any(o => o.Id == id)) //Database'de kayıt yoksa true değeri döndürür
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var ogr = await _context.Ogrenciler.FindAsync(id);
            if (ogr == null)
            {
                return NotFound();
            }
            return View("DeleteConfirm", ogr);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm]int id, Ogrenci model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Ogrenciler.Remove(model);
                    await _context.SaveChangesAsync();
                }
                catch (Exception)
                {
                    return NotFound();
                }
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}
