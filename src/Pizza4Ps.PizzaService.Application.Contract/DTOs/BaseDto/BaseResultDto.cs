using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.Contract.DTOs.BaseDto
{
    public class BaseResultDto<T>
    {
        [JsonPropertyName("items")]
        public List<T> Items { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }
    }
}
