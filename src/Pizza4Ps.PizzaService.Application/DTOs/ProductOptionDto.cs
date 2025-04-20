using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductOptionDto
    {
        public Guid Id { get; set; }

        public Guid OptionId { get; set; }

        public OptionDto Option { get; set; }
    }
}
