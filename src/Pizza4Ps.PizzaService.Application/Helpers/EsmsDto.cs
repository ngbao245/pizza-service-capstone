namespace Pizza4Ps.PizzaService.Domain.Abstractions
{
    // Models/EsmsRequest.cs
    public class EsmsRequest
    {
        public string ApiKey { get; set; }
        public string SecretKey { get; set; }
        public string Phone { get; set; }
        public string Content { get; set; }
        public string Brandname { get; set; }
        public string SmsType { get; set; }       // "0", "1" (OTP), "2" (Brandname)
        public string IsUnicode { get; set; }     // "0" or "1"
        public string Campaignid { get; set; }
        public string RequestId { get; set; }
        public string CallbackUrl { get; set; }
    }

    // Models/EsmsResponse.cs
    public class EsmsResponse
    {
        public string CodeResult { get; set; }
        public string ErrorMessage { get; set; }
        public string SMSID { get; set; }
        public string Message { get; set; }
        public string SendStatus { get; set; }
        public List<PhoneResult> PhoneNumberList { get; set; }
    }

    public class PhoneResult
    {
        public string PhoneNumber { get; set; }
        public string NetworkType { get; set; }
        public string NetworkName { get; set; }
    }

}
