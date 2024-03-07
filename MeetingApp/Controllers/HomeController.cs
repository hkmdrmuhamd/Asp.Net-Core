using Microsoft.AspNetCore.Mvc;
using MeetingApp.Models;

namespace MeetingApp.Controllers{
    public class HomeController: Controller{
        // localhost/home
        public IActionResult Index(){
            int saat = DateTime.Now.Hour;
            
            ViewData["Selamlama"] = saat > 12 ? "İyi Günler" : "Günaydın";
            var katilimci = Repository.Users.Where(info => info.WillAttend == true).Count();

            var meetingInfo = new MeetingInfo() {
                Id = 1,
                Location = "İzmir Abc Kongre Merkezi",
                Date = new DateTime(2024,03,07, 08, 43, 0),
                NumberOfPeople = katilimci

            };

            return View(meetingInfo);

            /* 
            var selamlama = saat > 12 ? "İyi Günler" : "Günaydın";
            return View(model: selamlama); gönderdiğimiz değerin bir model olduğunu belirtmemiz gerekir yoksa View olarak algılanır. cshtml dosyası olmadığından proje çöker. Gönerdiğimiz modeli kullanacağımız dizinde en üst satırda model tag'i ile belirmemiz gereklidir. Bu işlemler ViewBag ile de yapılabilir.*/
        }
    }
}