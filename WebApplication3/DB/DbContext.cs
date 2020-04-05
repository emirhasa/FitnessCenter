using Microsoft.EntityFrameworkCore;
using Seminarski_fitness_centar_IB130116.Models;

namespace Seminarski_fitness_centar_IB130116.DB
{
    public class MyContext : DbContext
    {
        //DbSet<...>
        public DbSet<User> Users { get; set; }
        public DbSet<Zaposlenik> Zaposlenici { get; set; }
        public DbSet<Admin> Admini { get; set; }
        public DbSet<Obavjestenje> Obavjestenja { get; set; }
        public DbSet<DolazakOdlazak> DolasciOdlasci { get; set; }
        public DbSet<Kontakt> Kontakti { get; set; }
        public DbSet<Adresa> Adrese { get; set; }
        public DbSet<Opstina> Opstine { get; set; }
        public DbSet<Grad> Gradovi { get; set; }
        public DbSet<MailPotvrda> MailPotvrde { get; set; }
        public DbSet<TwoFactorAuthentication> Autentifikacije { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = --; Initial Catalog = --; Persist Security Info = False; User ID = --; Password = --; MultipleActiveResultSets = False; Connection Timeout = 30;");
        }
    }
}
