using System.ComponentModel;

namespace EntityFrameworkApp.Data
{
    public class Kurs
    {
        [DisplayName("Kurs Id")]
        public int KursId { get; set; }
        [DisplayName("Kurs Ad�")]
        public string? Baslik { get; set; }
        public ICollection<KursKayit> KursKayitlari { get; set; } = new List<KursKayit>();
    }
}