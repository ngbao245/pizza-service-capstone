using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs.WebhookPayOsDto
{
    public class PayOSWebhookDto
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("data")]
        public PayOSWebhookDataDto Data { get; set; }

        [JsonPropertyName("signature")]
        public string Signature { get; set; }
    }
}
