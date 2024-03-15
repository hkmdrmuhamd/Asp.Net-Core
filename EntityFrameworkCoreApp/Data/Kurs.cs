using EntityFrameworkCoreApp.Data;
using System.ComponentModel;

namespace EntityFrameworkApp.Data
{
    public class Kurs
    {
        [DisplayName("Kurs Id")]
        public int KursId { get; set; }
        [DisplayName("Kurs Ad�")]
        public string? Baslik { get; set; }
        public int? OgretmenId { get; set; }
        public Ogretmen Ogretmen { get; set; } = null!;
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>(); //Bunun sebebi bir ��renci birden fazla kursa sahp olabilir
    }
}