using Microsoft.AspNetCore.Mvc;
using Cargo.Models;
using Cargo.Data;
namespace Cargo.Controllers
{

    /*
        -giris yapınca is Auth gelecek ardından                          tamam
        -giristsonrası sayfada manu sidebar olacak cargo işlemeleri      tamam
            ve profil işlemleri
        *               25 occtober
        - prepare the sendCargo form                                       tamam
        -update the database with adding the number and other field (now ı dunno ) tamam
        -update Database by addind the profile image url (again ı dunna how do to this ) tamam
        
    */



    public class AccountController : Controller
    {
        private readonly AppDbContext _context;

        public AccountController(AppDbContext context)
        {
            _context = context;
        }

        public List<string> GetAllUsersFullNames()
        {
            return _context.Users.Select(u => u.Fullname).ToList();
        }

        [HttpPost]
        public IActionResult BLogin(string email, string password)
        {
            // Veritabanında e-posta ve şifre eşleşmesini kontrol et
            var user = _context.BUsers.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                // Giriş başarılıysa
                Console.WriteLine("Giriş başarılı: " + email);

                // Kullanıcı bilgilerini Session'da sakla
                HttpContext.Session.SetInt32("UserId", user.Id);
                HttpContext.Session.SetString("UserEmail", user.Email);
                HttpContext.Session.SetString("UserFullName", user.Fullname);
                HttpContext.Session.SetString("UserAddress", user.Adress);
                HttpContext.Session.SetString("UserNumber", user.Number);
                // HttpContext.Session.SetString("UserImgUrl", user.ImgUrl);
                HttpContext.Session.SetString("UserPassword", user.Password);
                var all = GetAllUsersFullNames();
                
                var view = new PersonalMainPageViewModel
                {
                    User = user,
                    Fullnames = all
                };
                return View("PersonalMainPage", view);
              //  return RedirectToAction("PersonalMainPage", "Personal");  // Örneğin kişisel ana sayfaya yönlendirme
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
        public IActionResult BSign(string email, string password) //tamamlandı 
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
        public IActionResult KLogin(string email, string password, string fullname)//tamamandı 
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


