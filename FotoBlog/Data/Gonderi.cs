using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FotoBlog.Data
{
    public class Gonderi
    {
        public int Id { get; set; }

        [Display(Name = "Başlık")]
        [Required(ErrorMessage = "{0} alanı zorunludur.")]
        public string Baslik { get; set; } = null!;

        [Display(Name = "Resim")]
        [Required(ErrorMessage = "Lütfen bir {0} seçiniz.")]
        [MaxLength(255)]
        public string ResimYolu { get; set; } = null!;
    }
}
