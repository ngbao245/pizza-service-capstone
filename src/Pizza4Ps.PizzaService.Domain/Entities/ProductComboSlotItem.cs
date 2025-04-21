using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductComboSlotItem : EntityAuditBase<Guid>
    {
        public Guid ProductComboSlotId { get; set; }
        public virtual ProductComboSlot ProductComboSlot { get; set; } = null!; 

        public Guid? ProductId { get; set; }
        public virtual Product Product { get; set; } = null!; // Món thành phần trong combo slot

        public decimal ExtraPrice { get; set; }
        public ProductComboSlotItem()
        {
            
        }

        public ProductComboSlotItem(Guid id, Guid productComboSlotId, Guid productId, decimal extraPrice)
        {
            Id = id;
            ProductComboSlotId = productComboSlotId;
            ProductId = productId;
            ExtraPrice = extraPrice;
        }
    }
}
