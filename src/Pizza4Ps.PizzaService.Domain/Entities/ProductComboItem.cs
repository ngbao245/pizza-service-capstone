using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductComboItem : EntityAuditBase<Guid>
    {
        public Guid ComboId { get; set; }
        public virtual Product Combo { get; set; } = null!; // Sản phẩm combo (ProductRole = Combo)

        public Guid ProductId { get; set; }
        public virtual Product Product { get; set; } = null!; // Món thành phần trong combo

        public int Quantity { get; set; }
    }
}
