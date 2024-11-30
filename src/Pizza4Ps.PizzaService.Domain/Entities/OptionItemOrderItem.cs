using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OptionItemOrderItem : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionItemId { get; set; }
        public Guid OrderItemId { get; set; }

        public virtual OptionItem OptionItem { get; set; }
        public virtual OrderItem OrderItem { get; set; }

        public OptionItemOrderItem()
        {
        }

        public OptionItemOrderItem(string name, decimal additionalPrice, Guid optionItemId, Guid orderItemId)
        {
            Name = name;
            AdditionalPrice = additionalPrice;
            OptionItemId = optionItemId;
            OrderItemId = orderItemId;
        }
    }
}
