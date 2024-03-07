using MeetingApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace MeetingApp.Controllers
{
    public class MeetingController : Controller
    {
        //Aşağıdaki tanımladığımız Action Metotlarının defaultu HttpGet'tir. Özel olarak belirtmediğimiz sürece server bu şekilde algılar. [HttpGet] yazmasak bile server bunun Get isteği olduğunu algılar.
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Apply(){
            return View();
        }

        [HttpPost]
        public IActionResult Apply(UserInfo model){ //Formdan gelen verileri UserInfo modeline bind eder. Normelde burada tek tek string name, string phone vs. şeklinde alırdık. Ama model binding sayesinde bu işlemi yapmamıza gerek kalmaz.
            
            if (ModelState.IsValid){
                Repository.AddUser(model);
                ViewBag.UserCount = Repository.Users.Where(info => info.WillAttend == true).Count();
                return View("Thanks", model);
            }
            else{
                return View(model);
            }
        }

        public IActionResult List(){
            return View(Repository.Users);
        }

        public IActionResult Details(int id){
            return View(Repository.GetById(id));
        }
    }
}