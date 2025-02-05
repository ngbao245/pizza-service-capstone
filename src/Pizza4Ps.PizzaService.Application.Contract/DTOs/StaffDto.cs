using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.Contract.DTOs
{
    public class StaffDto
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("phone")]
        public string Phone { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("staffType")]
        public int StaffType { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

    }
}
