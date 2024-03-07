using basics.Models;
using Microsoft.AspNetCore.Mvc;

namespace basics.Controllers;

// course
public class CourseController : Controller
{
    //course/index
    public IActionResult Index(){
        var kurs = new Course(); //Tek bir kurs gönderimi

        kurs.Id = 1;
        kurs.Title = "AspNet Kursu";

        return View(kurs);
    }
    //course/details
    public IActionResult Details(int id){
        var kurs = Repository.GetById(id);
        return View(kurs);
    }
    //course/list
    public IActionResult List(){
        return View("List",Repository.Courses);
    }

    public IActionResult Deneme(){
        return View("DenemeView");
    }
}