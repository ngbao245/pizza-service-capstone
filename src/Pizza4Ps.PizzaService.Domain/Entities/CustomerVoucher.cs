using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class CustomerVoucher : EntityAuditBase<Guid>
    {
        public Guid CustomerId { get; set; }
        public Guid VoucherId { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Voucher Voucher { get; set; }

        public CustomerVoucher()
        {
        }

        public CustomerVoucher(Guid customerId, Guid voucherId)
        {
            CustomerId = customerId;
            VoucherId = voucherId;
        }


    }
}
