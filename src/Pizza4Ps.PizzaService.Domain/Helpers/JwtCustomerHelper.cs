using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pizza4Ps.PizzaService.Domain.Helpers
{
    public static class JwtCustomerHelper 
    {
        public static string GenerateJwtCustomerToken(IConfiguration configuration, AppUserCustomer appUserCustomer, DateTime expiredTime)
        {
            var claims = new List<Claim>
            {
                new Claim("CustomerId", appUserCustomer.Customer == null ? "" : appUserCustomer.Customer.Id.ToString()),
                new Claim("AppUserCustomerId", appUserCustomer.Id.ToString() ?? ""),
                new Claim(ClaimTypes.Role, "Customer"),
                new Claim(JwtRegisteredClaimNames.UniqueName, appUserCustomer.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Name, appUserCustomer.Customer == null ? "" : appUserCustomer.Customer.FullName ?? "")
            };

            // Cấu hình JWT
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiredTime,
                SigningCredentials = creds
            }; 
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
    }
}
