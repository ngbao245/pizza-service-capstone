using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class OptionItem : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public decimal AdditionalPrice { get; set; }
        public Guid OptionId { get; set; }

        public virtual Option Option { get; set; }
        public virtual ICollection<OptionItemOrderItem> OptionItemOrderItems { get; set; }

        public OptionItem()
        {
        }

        public OptionItem(string name, decimal additionalPrice, Guid optionId)
        {
            Name = name;
            AdditionalPrice = additionalPrice;
            OptionId = optionId;
        }
    }
}