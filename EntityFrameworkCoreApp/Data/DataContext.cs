using EntityFrameworkCoreApp.Data;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkApp.Data
{
    public class DataContext: DbContext //Bu kullanım ile database ile bağlantı sağlanmış oluyor.
    {
        public DataContext(DbContextOptions<DataContext> options): base(options)
        {
            
        }
        public DbSet<Kurs> Kurslar => Set<Kurs>(); //Set<Kurs>() methodu ile Kurs sınıfı DbSet'e dönüştürüldü.
        public DbSet<Ogrenci> Ogrenciler => Set<Ogrenci>(); 
        public DbSet<KursKayit> KursKayitlari => Set<KursKayit>();
        public DbSet<Ogretmen> Ogretmenler => Set<Ogretmen>();

    }
}