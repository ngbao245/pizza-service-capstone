using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class AdditionalFee : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public Guid OrderId { get; set; }

        public virtual Order Order { get; set; }

        public AdditionalFee()
        {
        }

        public AdditionalFee(Guid id, string name, string description, decimal value, Guid orderId)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = ValidateValue(value);
            OrderId = orderId;
        }

        private decimal ValidateValue(decimal value)
        {
            //if (value < 0)
            //{
            //    throw new BusinessException(BussinessErrorConstants.AdditionalFeeErrorConstant.VALUE_INVALID);
            //}
            return value;
        }

    }
}
