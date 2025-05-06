using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OptionItemDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }

        public Guid OptionID { get; set; }
        public string OptionItemStatus { get; set; }
        [JsonIgnore]
        public OptionDto Option { get; set; }
        //public Guid OptionId { get; set; }

        //public virtual OptionDto Option { get; set; }
    }
}
