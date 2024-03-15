using EntityFrameworkApp.Data;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreApp.Data
{
    public class Ogretmen
    {
        [Key]
        public int OgretmenId { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }
        public DateTime BaşlamaTarihi { get; set; }
        public ICollection<Kurs> Kurslar { get; set; } = new List<Kurs>();
    }
}
