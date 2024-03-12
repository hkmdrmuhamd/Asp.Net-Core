using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkApp.Data
{
    public class Ogrenci
    {
        [Key]
        public int Id { get; set; } /*Bu id değeri primary key olmak zorundadır. Fakat eğer Id olarak belirlersek veya
            class adı Id => OgrenciId şeklinde belirlersek asp.net [Key] şeklinde belirtsek de belirmesek de bunun bir primary key olduğunu anlar 
            fakat eğer özel bir isim vermek istiyorsak: mesela OgrenciKimlik gibi o zaman kolonumuzun üstüne [Key] şeklinde belirtmemiz gereklidir.*/
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Email { get; set; }
        public string? Telefon { get; set; }

    }
}