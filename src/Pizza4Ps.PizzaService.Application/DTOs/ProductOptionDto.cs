using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductOptionDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid OptionId { get; set; }

        public virtual ProductDto Product { get; set; }
        public virtual OptionDto Option { get; set; }
    }
}
