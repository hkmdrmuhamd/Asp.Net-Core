using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using ProductsAPI.Models;

namespace ProductsAPI.Services
{
    public class JwtToken
    {
        private readonly IConfiguration _configuration;
        public JwtToken(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateJWT(AppUser user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value ?? ""); //Burada uapılan işlem AppSettings dosyasındaki Secret'i bul ve o değeri al değer yoksa boş değer ata.
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
                    new Claim[] { //Token üretilirken içerisinde olmasını istediğimiz bilgileri ekleriz.
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), //Kullanıcı id değeri
                        new Claim(ClaimTypes.Name, user.UserName ?? ""),
                    }
                ),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature), //token'i şifrelemek içindir
                Issuer = "muhammedhkmdr.com" //api'nin kim tarafından sağlandığını belirtir.
            };
            var token = tokenHandler.CreateToken(tokenDescriptor); //Token'i oluşturmak için kullanılır.
            return tokenHandler.WriteToken(token);
        }
    }
}