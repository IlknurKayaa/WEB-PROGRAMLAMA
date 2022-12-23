using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Kullanici
    {
        [Key] public int KullaniciId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name="Adı")]
        public string KullaniciAd { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Soyadı")]
        public string KullaniciSoyad { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name = "Kullanıcı Adı")]
        public string KullaniciAdId { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Şifre")]
        public string Sifre { get; set; }
        public int RolId { get; set; }    



    }
}
