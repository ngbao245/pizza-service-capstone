using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductComboSlot : EntityAuditBase<Guid>
    {
        public Guid? ComboId { get; set; }
        public virtual Product Combo { get; set; } = null!; // Sản phẩm combo (ProductRole = Combo)

        public string SlotName { get; set; }
        public virtual ICollection<ProductComboSlotItem> ProductComboSlotItems { get; set; } = new List<ProductComboSlotItem>();

        public ProductComboSlot()
        {

        }

        public ProductComboSlot(Guid id, Guid comboId, string slotname)
        {
            Id = id;
            ComboId = comboId;
            SlotName = slotname;
        }
    }
}
