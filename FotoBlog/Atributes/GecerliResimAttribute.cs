using System.ComponentModel.DataAnnotations;

namespace FotoBlog.Atributes
{
    public class GecerliResimAttribute : ValidationAttribute
    {
       
        public double MaxDosyaboyutuMB { get; set; } = 1;

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var dosya = (IFormFile?)value;
            if (dosya == null) return ValidationResult.Success;

            if (!dosya.ContentType.StartsWith("image/"))
            {
                return new ValidationResult("Geçersiz resim dosyası.");
            }
            else if (dosya.Length > MaxDosyaboyutuMB * 1024 * 1024)
            {
                return new ValidationResult($"Maksimum dosya boyutu: {MaxDosyaboyutuMB} MB");
            }


            return ValidationResult.Success;
        }
    }


}
