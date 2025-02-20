using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs.WebhookPayOsDto
{
    public class PayOSWebhookDataDto
    {
        [JsonPropertyName("orderCode")]
        public int OrderCode { get; set; }

        [JsonPropertyName("amount")]
        public int Amount { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("accountNumber")]
        public string AccountNumber { get; set; }

        [JsonPropertyName("reference")]
        public string Reference { get; set; }

        [JsonPropertyName("transactionDateTime")]
        public string TransactionDateTime { get; set; }
        // Nếu cần chuyển sang DateTime, có thể parse theo định dạng "yyyy-MM-dd HH:mm:ss"

        [JsonPropertyName("currency")]
        public string Currency { get; set; }

        [JsonPropertyName("paymentLinkId")]
        public string PaymentLinkId { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("desc")]
        public string Desc { get; set; }

        [JsonPropertyName("counterAccountBankId")]
        public string CounterAccountBankId { get; set; }

        [JsonPropertyName("counterAccountBankName")]
        public string CounterAccountBankName { get; set; }

        [JsonPropertyName("counterAccountName")]
        public string CounterAccountName { get; set; }

        [JsonPropertyName("counterAccountNumber")]
        public string CounterAccountNumber { get; set; }

        [JsonPropertyName("virtualAccountName")]
        public string VirtualAccountName { get; set; }

        [JsonPropertyName("virtualAccountNumber")]
        public string VirtualAccountNumber { get; set; }
    }
}
