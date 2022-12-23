using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Makale
    {
        [Key] public int MakaleId { get; set; }
        [Required]
        [MaxLength(100)]
        [Display(Name=" Makale Adı")]
        public string MakaleAd { get; set; }
        [Range (100,1500,ErrorMessage ="Makale Sayfası 0-50 arası olmak zorundadır.")]
        public int MakaleSayfasi { get; set; }
        public int KullaniciId { get; set; }
        public Kullanici Kullanici { get; set; }


    }
}
