using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.Contract.DTOs.BaseDto
{
    public class BaseApiResponseDto<T>
    {
        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("result")]
        public BaseResultDto<T> Result { get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("statusCode")]
        public int StatusCode { get; set; }
    }
}
