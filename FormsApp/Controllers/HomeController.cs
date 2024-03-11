using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Runtime.CompilerServices;

namespace FormsApp.Controllers;

public class HomeController : Controller
{

    public IActionResult Index(string searchString, string category)
    {
        var products = Repository.Products;
        if (!string.IsNullOrEmpty(searchString))
        {
            ViewBag.SearchString = searchString; // ViewBag ile view'deki input alanına değer gönderiyoruz. Bu alandaki SeachString ismi view'deki input alanının value'sunda kullanılan değer ile aynı olmalıdır.
            products = products.Where(p => p.Name.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
        }
        if(!string.IsNullOrEmpty(category) && category != "0")
        {
            products = products.Where(p => p.CategoryId == int.Parse(category)).ToList();
        }

        //ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");

        var model = new ProductViewModel 
        { 
            Products = products, 
            Categories = Repository.Categories, 
            SelectedCategory = category  
        };
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name"); 
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product model, IFormFile imageFile)//bu şekilde bir kullanımda tüm product değerleri gönderilir. Belirli bazı product modellerini göndermek istiyorsak:
        //public IActionResult Create([Bind("Name","Price")] Product Model) bu şekilde bir kullanım yapılabilir. (Model Binding)
    {
        if (imageFile != null)
        {
            var extension = Path.GetExtension(imageFile.FileName).ToLower(); //Yüklenecek olan resmin uzantısını alır.
            var allowedExtensions = new[] { ".jpg", ".jpeg", ".png" };

            if (!allowedExtensions.Contains(extension))
            {
                ModelState.AddModelError("", "Sadece jpg, jpeg ve png uzantılı doslayaları seçebilirsiniz.");
            }
            else
            {
                var randomFileName = $"{Guid.NewGuid().ToString()}{extension}"; //random file name üretir ve resmin uzantısını bu random name'in sonuna ekler.
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName); //resmin kaydedileceği dizin

                using (var stream = new FileStream(path, FileMode.Create)) // Yüklenen dosyanın içeriği, belirtilen dosya yoluna (path) kopyalanır.
                {
                    await imageFile.CopyToAsync(stream);
                }

                model.Image = randomFileName;
                model.ProductId = Repository.Products.Count + 1;
                Repository.CreateProduct(model);
                return RedirectToAction("Index"); //İşlem bittikten sonra Index methoduna redirect ettik yani işlem tamamlandıktan sonra Index methodu çalışır.
            }
        }
        else
        {
            ModelState.AddModelError("", "Lütfen bir resim seçiniz.");
        }

        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name"); //Kategorilerin içini doldurmak için yapılır.
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int? id)
    {
        if(id == null)
        {
            return NotFound(); //404 sayfası basılır.
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id); //FirstOrDefault şartı sağlayan ilk ürünü alıp entity'e atar
        if (entity == null)
        {
            return NotFound();
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(int id, Product product, IFormFile? imageFile)
    {
        if (id != product.ProductId)
        {
            return NotFound();
        }
        if (ModelState.IsValid)
        {
            if(imageFile != null)
            {
                var extension = Path.GetExtension(imageFile.FileName).ToLower();
                var randomFileName = $"{Guid.NewGuid().ToString()}{extension}"; 
                var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", randomFileName);
                
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await imageFile.CopyToAsync(stream);
                }
                product.Image = randomFileName;
            }
            Repository.EditProduct(product);
            return RedirectToAction("Index");
        }
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name");
        return View(product);
    }

    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }
        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if (entity == null)
        {
            return NotFound();
        }
        return View("DeleteConfirm", entity);
    }
    
    [HttpPost]
    public IActionResult Delete(int id, int ProductId)
    {
        if(id != ProductId)
        {
            return NotFound();
        }

        var entity = Repository.Products.FirstOrDefault(p => p.ProductId == id);
        if(entity == null)
        {
            return NotFound();
        }

        Repository.DeleteProduct(entity);
        return RedirectToAction("Index");
    }

}
