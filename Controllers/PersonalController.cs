using Microsoft.AspNetCore.Mvc;

namespace Cargo.Controllers
{
    public class PersonalController : Controller
    {
        public IActionResult PersonalMainPage()
        {
            return View(); // Ana sayfa
        }
        [HttpGet]
        public IActionResult SendCargo()
        {
            Console.WriteLine("send kargı");
            return PartialView("_SendCargo"); // Kargo gönderim sayfası için partial view
        }
        [HttpGet]
        public IActionResult Profile()
        {
            Console.Write("profil sayfası ");
            return PartialView("_Profile"); // Profil sayfası için partial view
        }

        public IActionResult ControlCargo()
        {
            return PartialView("_ControlCargo"); // Ayarlar sayfası için partial view
        }

        public IActionResult Support()
        {
            return PartialView("_Support"); // Destek sayfası için partial view
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("BLogin", "Account"); // Redirecting to the BLogin action of Account controller    }
        }

    }
}
