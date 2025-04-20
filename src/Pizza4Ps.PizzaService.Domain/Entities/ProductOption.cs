using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class ProductOption : EntityAuditBase<Guid>
    {
        public Guid ProductId { get; set; }

        public Product Product { get; set; }

        public Guid OptionId { get; set; }

        public Option Option { get; set; }

        public ProductOption() { }

        public ProductOption(Guid productId, Guid optionId)
        {
            ProductId = productId;
            OptionId = optionId;
        }
    }
}
