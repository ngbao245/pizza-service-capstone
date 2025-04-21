using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductComboSlotDto
    {
        public Guid Id { get; set; }
        public string SlotName { get; set; }
        public virtual ICollection<ProductComboSlotItemDto> ProductComboSlotItems { get; set; } = new List<ProductComboSlotItemDto>();
    }
}
