using Microsoft.AspNetCore.Mvc;
using Cargo.Models;
using Cargo.Data;
using System.Linq;
namespace Cargo.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }


      
     
        [HttpPost]
        public IActionResult BLogin(string email, string password)
        {
            Console.WriteLine("wmial:",email);
            Console.WriteLine("password:",password);
           var user = _context.BUsers.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Giriş başarılıysa
                Console.WriteLine("Giriş başarılı: " + email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısızsa
                Console.WriteLine("Giriş başarısız. Yanlış e-posta veya şifre.");
                ModelState.AddModelError("", "Yanlış e-posta veya şifre.");
                return View("BireyselLogIn");
            }
        }

     
        [HttpPost]
        public IActionResult BSign(string email, string password)
        {
            var existingUser = _context.BUsers.SingleOrDefault(u => u.Email == email);

            if (existingUser != null)
            {
                // Eğer kullanıcı varsa hata mesajı göster
                ModelState.AddModelError("", "Bu email adresi ile kayıtlı bir kullanıcı zaten var.");
                return View("BireyselSignIn");
            }

            // Yeni bir Bireysel Kullanıcı oluştur ve veritabanına ekle
            var newUser = new BUser
            {
                Email = email,
                Password = password
            };

            _context.BUsers.Add(newUser);
            _context.SaveChanges(); // Veritabanına kaydet

            Console.WriteLine("Yeni kullanıcı kaydedildi: " + email);

            // Başarılı kayıt sonrası giriş sayfasına yönlendirme
            return RedirectToAction("BLogin", "Account");
        }
   

        
        [HttpPost]
        public IActionResult KLogin(string email, string password)//tamamandı 
        {
            // Veritabanında e-posta ve şifre eşleşmesini kontrol et
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Giriş başarılıysa
                Console.WriteLine("Giriş başarılı: " + email);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                // Giriş başarısızsa
                Console.WriteLine("Giriş başarısız. Yanlış e-posta veya şifre.");
                ModelState.AddModelError("", "Yanlış e-posta veya şifre.");
                return View("KurumsalLogIn");
            }
        }
      

        [HttpGet]
        public IActionResult BLogin()//tamamlandı
        {
            // GET isteği ile formun ilk kez yüklenmesi
            return View("BireyselLogIn");
        }

   
        [HttpGet]
        public IActionResult BSign()//tamamlandı
        {
            // GET isteği ile formun ilk kez yüklenmesi
            return View("BireyselSignIn");
        }

        [HttpGet]
        public IActionResult KLogin()// tamamlandı 
        {
            // GET isteği ile formun ilk kez yüklenmesi
            return View("KurumsalLogIn");
        }

   
    }







}


