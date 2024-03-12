using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; } /*Bu id de�eri primary key olmak zorundad�r. Fakat e�er Id olarak belirlersek veya
            class ad� Id => OgrenciId �eklinde belirlersek asp.net [Key] �eklinde belirtsek de belirmesek de bunun bir primary key oldu�unu anlar 
            fakat e�er �zel bir isim vermek istiyorsak: mesela OgrenciKimlik gibi o zaman kolonumuzun �st�ne [Key] �eklinde belirtmemiz gereklidir.*/
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

    }
}