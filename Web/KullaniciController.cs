using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class KullaniciController : Controller
    {
        MakaleContext _context = new MakaleContext();
        public IActionResult Index()
        {
            var kullanici = _context.kullanicis;

            return View(kullanici);
        }
        public IActionResult KullaniciEkle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult KullaniciEkle(Kullanici kul)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kul);
                _context.SaveChanges();
                TempData["msj"] = kul.KullaniciAd + " adlı kullanici kayıdı tamamlandı.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("KullaniciEkle");
            }


        }
    }
}
