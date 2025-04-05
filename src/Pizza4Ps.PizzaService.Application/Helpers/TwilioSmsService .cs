using Microsoft.Extensions.Configuration;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Pizza4Ps.PizzaService.Application.Helpers
{
    public class TwilioSmsService 
    {
        private readonly IConfiguration _config;

        public TwilioSmsService(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendOtpAsync(string phoneNumber, string otpCode)
        {
            var accountSid = _config["Twilio:AccountSid"];
            var authToken = _config["Twilio:AuthToken"];
            var fromPhone = _config["Twilio:FromPhoneNumber"];

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                body: $"Your OTP code is: {otpCode}",
                from: new Twilio.Types.PhoneNumber(fromPhone),
                to: new Twilio.Types.PhoneNumber(ToInternationalPhone(phoneNumber))
            );
        }
        public static string ToInternationalPhone(string localPhone)
        {
            if (string.IsNullOrWhiteSpace(localPhone))
                throw new ArgumentException("Phone number is required.");

            // Xóa dấu cách, dấu - hoặc các ký tự không cần thiết
            var digitsOnly = new string(localPhone.Where(char.IsDigit).ToArray());

            if (digitsOnly.StartsWith("0"))
            {
                return "+84" + digitsOnly.Substring(1); // Bỏ số 0 đầu tiên
            }

            // Nếu đã là dạng +84 rồi thì giữ nguyên
            if (digitsOnly.StartsWith("84"))
            {
                return "+84" + digitsOnly.Substring(2);
            }

            // Nếu không bắt đầu bằng 0 hoặc 84 thì cứ thêm +84
            return "+84" + digitsOnly;
        }
    }

}
