using FotoBlog.Atributes;
using System.ComponentModel.DataAnnotations;

namespace FotoBlog.Models
{
    public class YeniGonderiViewModel
    {
        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Baslik { get; set; } = null!;

        [Display(Name = "Resim")]
        [Required(ErrorMessage = "Lütfen bir {0} seçiniz.")]
        [GecerliResim (MaxDosyaboyutuMB = 1.2)]
        public IFormFile Resim { get; set; } = null!;
    }
}
