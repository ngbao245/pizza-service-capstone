using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Voucher : EntityAuditBase<Guid>
    {
        public string Code { get; set; }
        public DiscountTypeEnum DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        // Trạng thái claim voucher
        //public bool IsClaimed { get; set; }           // false: chưa được claim; true: đã claim
        //public DateTime? ClaimedAt { get; set; }        // Thời gian khách hàng claim voucher
        //public Guid? ClaimedByCustomerId { get; set; }  // ID khách hàng claim voucher
        //public decimal ChangePoint { get; set; }     // Điểm đổi voucher
        public VoucherStatus VoucherStatus { get; set; }       

        // Liên kết đến đợt phát hành
        public Guid? VoucherBatchId { get; set; }
        public VoucherBatch VoucherBatch { get; set; }

        public Voucher()
        {
        }

        public Voucher(string code, DiscountTypeEnum discountType, decimal discountValue, Guid? voucherBatchId)
        {
            Id = Guid.NewGuid();
            Code = code;
            DiscountType = discountType;
            DiscountValue = discountValue;
            VoucherBatchId = voucherBatchId;
            VoucherStatus = VoucherStatus.Available;
        }

        public void SetUsed()
        {
            VoucherStatus = VoucherStatus.Used;
        }

        public void SetInvalid()
        {
            VoucherStatus = VoucherStatus.Invalid;
        }

        public void SetPendingPayment()
        {
            VoucherStatus = VoucherStatus.PendingPayment;
        }

        public void SetAvailable()
        {
            VoucherStatus = VoucherStatus.Available;
        }

        ///// <summary>
        ///// Phương thức claim voucher
        ///// </summary>
        ///// <param name="claimedById">ID của người claim voucher</param>
        //public void Claim(Guid claimedById)
        //{
        //    // Kiểm tra xem voucher đã được claim chưa
        //    if (IsClaimed)
        //    {
        //        throw new BusinessException("Voucher đã được claim.");
        //    }

        //    // Kiểm tra xem voucher có còn trong thời gian hiệu lực không (nếu cần)
        //    if (VoucherBatch != null)
        //    {
        //        if (DateTime.UtcNow < VoucherBatch.StartDate || DateTime.UtcNow > VoucherBatch.EndDate)
        //        {
        //            throw new BusinessException("Voucher không nằm trong thời gian hiệu lực.");
        //        }
        //    }

        //    // Đánh dấu voucher đã được claim
        //    IsClaimed = true;
        //    ClaimedAt = DateTime.UtcNow;
        //    ClaimedByCustomerId = claimedById;
        //}
    }
}
