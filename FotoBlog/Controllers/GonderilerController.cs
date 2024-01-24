using FotoBlog.Data;
using FotoBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace FotoBlog.Controllers
{
    public class GonderilerController : Controller
    {
        private readonly UygulamaDBContext _db;
        private readonly IWebHostEnvironment _env;

        public GonderilerController(UygulamaDBContext db, IWebHostEnvironment env)
        {
            _db = db;
            _env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Yeni()
        {
            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Yeni(YeniGonderiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                string dosyaAd = vm.Resim.FileName; //dosya adını al
                string ext = Path.GetExtension(dosyaAd); //uzantı al
                string yeniDosyaAd = Guid.NewGuid() + ext;
                string yol = Path.Combine(_env.WebRootPath, "img", "upload", yeniDosyaAd);

                using (var fs = new FileStream(yol, FileMode.CreateNew))
                {
                    vm.Resim.CopyTo(fs);
                }

                Gonderi newPost = new Gonderi();
                newPost.Baslik = vm.Baslik;
                newPost.ResimYolu = yeniDosyaAd;

                _db.Gonderiler.Add(newPost);
                _db.SaveChanges();

                return RedirectToAction("Index", "Home", new { Sonuc = "Eklendi" });
            }

            return View();
        }
    }
}
