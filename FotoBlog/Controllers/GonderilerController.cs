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


        public IActionResult Guncelle(int id)
        {

            var guncellenecekPost = _db.Gonderiler.Find(id);

            YeniGonderiViewModel guncellenecekModel = new YeniGonderiViewModel();
            guncellenecekModel.Baslik = guncellenecekPost!.Baslik;

            TempData["Id"] = guncellenecekPost.Id;

            return View(guncellenecekModel);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public IActionResult Guncelle(YeniGonderiViewModel vm)
        {
            var guncellenecekPost = _db.Gonderiler.Find(TempData["Id"])!;

            try
            {
                if (vm.Resim != null && vm.Resim.FileName != guncellenecekPost.ResimYolu)
                {
                    ResimSil(guncellenecekPost);

                    string dosyaAd = vm.Resim.FileName; //dosya adını al
                    string ext = Path.GetExtension(dosyaAd); //uzantı al
                    string yeniDosyaAd = Guid.NewGuid() + ext;
                    string yol = Path.Combine(_env.WebRootPath, "img", "upload", yeniDosyaAd);

                    using (var fs = new FileStream(yol, FileMode.CreateNew))
                    {
                        vm.Resim.CopyTo(fs);
                    }

                    guncellenecekPost.ResimYolu = yeniDosyaAd;
                }

                guncellenecekPost.Baslik = vm.Baslik;
                _db.Gonderiler.Update(guncellenecekPost);
                _db.SaveChanges();
                return RedirectToAction("Index", "Home");

            }
            catch (Exception ex)
            {
                TempData["Durum"] = "Hata oluştu! " + ex.Message;
                return View();
            }

        }


        public IActionResult Sil(int id)
        {
            Gonderi post = _db.Gonderiler.Find(id)!;
            return View(post);
        }

        [HttpPost]
        public IActionResult Sil(Gonderi post)
        {
            ResimSil(post);
            _db.Gonderiler.Remove(post);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public void ResimSil(Gonderi gonderi)
        {
            var resmiKullananBaskaVarMi = _db.Gonderiler.Any(g => g.ResimYolu == gonderi.ResimYolu && g.Id != gonderi.Id);

            if (gonderi.ResimYolu != null && !resmiKullananBaskaVarMi)
            {
                string dosya = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/upload", gonderi.ResimYolu);
                System.IO.File.Delete(dosya);
            }

        }

    }
}
