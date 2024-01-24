using Microsoft.EntityFrameworkCore;

namespace FotoBlog.Data
{
    public class UygulamaDBContext : DbContext
    {
        public UygulamaDBContext(DbContextOptions<UygulamaDBContext> options) : base(options)
        {

        }

        public DbSet<Gonderi> Gonderiler { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gonderi>().HasData(
                new Gonderi { Id = 1, Baslik = "Batarken güneş ardında tepelerin, veda vakti geldi teletabilerin..", ResimYolu = "gunbatimi.jpg" },
                new Gonderi { Id = 2, Baslik = "Derin mavilerde, su altı masalı coşkuyla dans eder, Balıkların ışıltılı gölgesi, gizemli bir dünyayı örer..", ResimYolu = "sualti.jpg" }
                );
        }
    }
}
