using System.Security.Cryptography;
using System.Text;

namespace Pizza4Ps.PizzaService.Domain.Helpers
{
    public static class PasswordHelperCustomer
    {
        public static void CreatePasswordHash(string password, out string passwordHash, out string salt)
        {
            using var hmac = new HMACSHA256();
            salt = Convert.ToBase64String(hmac.Key);
            passwordHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password + salt)));
        }

        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            using var hmac = new HMACSHA256(Convert.FromBase64String(storedSalt));
            var computedHash = Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password + storedSalt)));
            return computedHash == storedHash;
        }
    }
}
