using System.ComponentModel;

namespace EntityFrameworkApp.Data
{
    public class Kurs
    {
        [DisplayName("Kurs Id")]
        public int KursId { get; set; }
        [DisplayName("Kurs Adý")]
        public string? Baslik { get; set; }
    }
}