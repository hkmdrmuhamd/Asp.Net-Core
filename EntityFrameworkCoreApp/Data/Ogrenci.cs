using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("Öðrenci Id'si")]
        public int Id { get; set; } /*Bu id deðeri primary key olmak zorundadýr. Fakat eðer Id olarak belirlersek veya
            class adý Id => OgrenciId þeklinde belirlersek asp.net [Key] þeklinde belirtsek de belirmesek de bunun bir primary key olduðunu anlar 
            fakat eðer özel bir isim vermek istiyorsak: mesela OgrenciKimlik gibi o zaman kolonumuzun üstüne [Key] þeklinde belirtmemiz gereklidir.*/
        [DisplayName("Öðrencinin Adý")]
        public string? Ad { get; set; }
        [DisplayName("Öðrencinin Soyadý")]
        public string? Soyad { get; set; }
        public string AdSoyad { 
            get
            {
                return this.Ad + " " + this.Soyad;
            } 
        }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

    }
}