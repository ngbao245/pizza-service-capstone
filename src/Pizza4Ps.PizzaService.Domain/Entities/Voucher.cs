using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        // Trạng thái claim voucher
        public bool IsClaimed { get; set; }           // false: chưa được claim; true: đã claim
        public DateTime? ClaimedAt { get; set; }        // Thời gian khách hàng claim voucher
        public Guid? ClaimedByCustomerId { get; set; }  // ID khách hàng claim voucher


        // Liên kết đến đợt phát hành
        public Guid? VoucherBatchId { get; set; }
        public VoucherBatch VoucherBatch { get; set; }

        public Voucher()
        {
        }

        //public Voucher(Guid id, string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId)
        //{
        //    Id = id;
        //    Code = code;
        //    DiscountType = discountType;
        //    ExpiryDate = expiryDate;
        //    VoucherTypeId = voucherTypeId;
        //}

        //public void UpdateVoucher(string code, DiscountTypeEnum discountType, DateTime expiryDate, Guid voucherTypeId)
        //{
        //    Code = code;
        //    DiscountType = discountType;
        //    ExpiryDate = expiryDate;
        //    VoucherTypeId = voucherTypeId;
        //}
    }
}
