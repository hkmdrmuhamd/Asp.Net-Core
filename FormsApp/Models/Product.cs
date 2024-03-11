using System.ComponentModel.DataAnnotations;
namespace FormsApp.Models
{
    //[Bind("Name","Price")] bu kullanım ile sadece Name ve Price ögelerini kullanabiliriz
    public class Product
    {
        //[BindNever] bu kullanım ise tüm objeler bind edilsin fakat bu obje bind edilmesin anlamında kullanılır.
        [Display(Name = "Ürün Id")]
        public int ProductId { get; set; }

        [Display(Name = "Ürün Adı")]
        [Required(ErrorMessage = "Ürün adı alanı boş geçilemez")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Fiyat")]
        [Required(ErrorMessage = "Ürün fiyatı alanı boş geçilemez")]
        public decimal? Price { get; set; }

        [Display(Name = "Resim")]
        [Required(ErrorMessage = "Ürün fotoğrafı alanı boş geçilemez")]
        public string Image { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        [Display(Name = "Kategoriler")]
        [Required(ErrorMessage = "Ürün kategorisi alanı boş geçilemez")]
        public int CategoryId { get; set; }
    }
}