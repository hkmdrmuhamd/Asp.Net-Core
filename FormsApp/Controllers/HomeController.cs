using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FormsApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        ViewBag.Categories = new SelectList(Repository.Categories, "CategoryId", "Name"); //Kategorilerin içini doldurmak için yapılır.
        return View();
    }

    [HttpPost]
    public IActionResult Create(Product model) //bu şekilde bir kullanımda tüm product değerleri gönderilir. Belirli bazı product modellerini göndermek istiyorsak:
        //public IActionResult Create([Bind("Name","Price")] Product Model) bu şekilde bir kullanım yapılabilir
    {
        Repository.CreateProduct(model);
        return RedirectToAction("Index"); //İşlem bittikten sonra Index methoduna redirect ettik yani işlem tamamlandıktan sonra Index methodu çalışır.
        
    }
}
