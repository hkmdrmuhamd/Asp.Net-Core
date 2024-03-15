using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogrenci
    {
        [Key]
        [DisplayName("��renci Id'si")]
        public int Id { get; set; } /*Bu id de�eri primary key olmak zorundad�r. Fakat e�er Id olarak belirlersek veya
            class ad� Id => OgrenciId �eklinde belirlersek asp.net [Key] �eklinde belirtsek de belirmesek de bunun bir primary key oldu�unu anlar 
            fakat e�er �zel bir isim vermek istiyorsak: mesela OgrenciKimlik gibi o zaman kolonumuzun �st�ne [Key] �eklinde belirtmemiz gereklidir.*/
        [DisplayName("��rencinin Ad�")]
        public string? Ad { get; set; }
        [DisplayName("��rencinin Soyad�")]
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