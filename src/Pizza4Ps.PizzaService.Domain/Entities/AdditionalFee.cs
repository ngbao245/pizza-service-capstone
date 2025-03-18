using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class AdditionalFee : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }

        public AdditionalFee()
        {
        }

        public AdditionalFee(Guid id, string name, string description, decimal value)
        {
            Id = id;
            Name = name;
            Description = description;
            Value = ValidateValue(value);
        }

        private decimal ValidateValue(decimal value)
        {
            if (value < 0)
            {
                throw new BusinessException(BussinessErrorConstants.AdditionalFeeErrorConstant.VALUE_INVALID);
            }
            return value;
        }

    }
}
