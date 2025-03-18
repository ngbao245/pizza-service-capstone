using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class VoucherType : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int TotalQuantity { get; set; }

        public VoucherType(string name, string description, int totalQuantity)
        {
            Name = name;
            Description = description;
            TotalQuantity = ValidateTotalQuantity(totalQuantity);
        }

        private int ValidateTotalQuantity(int totalQuantity)
        {
            if (totalQuantity <= 0)
            {
                throw new BusinessException(BussinessErrorConstants.VoucherTypeErrorConstant.TOTAL_QUANTITY_INVALID);
            }
            return totalQuantity;
        }
    }
}