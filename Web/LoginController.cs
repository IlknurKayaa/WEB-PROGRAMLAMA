using loginn.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace loginn.Controllers
{
    public class LoginController : Controller
    {
        Context c=new Context();
        [HttpGet]
        [AllowAnonymous]
        public IActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]

        public async Task<IActionResult> GirisYap(Kullanicilar p)
        {
            var bilgiler=c.Kullanicilar.FirstOrDefault(x=>x.KullaniciAd==p.KullaniciAd
            &&x.KullaniciSifre==p.KullaniciSifre);
            if (bilgiler != null)
            {
                var claims = new List<Claim>
                     {
                    new Claim(ClaimTypes.Name,p.KullaniciAd)
                };
                var useridentity = new ClaimsIdentity(claims, "Login");
                ClaimsPrincipal principal = new ClaimsPrincipal(useridentity);
                await HttpContext.SignInAsync(principal);
                return RedirectToAction("Index","Makale");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index","Makale");
        }
    }
}

        
