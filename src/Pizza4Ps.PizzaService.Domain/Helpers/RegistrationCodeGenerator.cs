namespace Pizza4Ps.PizzaService.Domain.Helpers
{
    public static class RegistrationCodeGenerator
    {
        public static string GenerateCode(int length = 8)
        {
            var timestamp = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds(); // Lấy timestamp hiện tại
            var random = new Random();
            var randomDigits = random.Next(100000, 999999); // Random 6 chữ số

            string code = (timestamp % 1000000).ToString() + randomDigits.ToString(); // Lấy 6 số cuối của timestamp
            return code.Substring(0, length); // Cắt đúng độ dài mong muốn
        }
    }
}
