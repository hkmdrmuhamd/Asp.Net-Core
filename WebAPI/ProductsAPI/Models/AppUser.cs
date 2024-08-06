using Microsoft.AspNetCore.Identity;

namespace ProductsAPI.Models
{
    public class AppUser : IdentityUser<int> //int olarak belirlememizin sebebi eklenen kullanıcıları 1 2 3 şeklinde sırayla ekler default'u string'dir.
    {
        public string FullName { get; set; } = null!;
        public DateTime DateAdded { get; set; }
    }
}