using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class VoucherDto
    {
        public Guid Id { get; set; }    
        public string Code { get; set; }
        public string DiscountType { get; set; }
        public decimal DiscountValue { get; set; }
        // Trạng thái claim voucher
        public bool IsClaimed { get; set; }           // false: chưa được claim; true: đã claim
        public DateTime? ClaimedAt { get; set; }        // Thời gian khách hàng claim voucher
        public Guid? ClaimedByCustomerId { get; set; }  // ID khách hàng claim voucher


        // Liên kết đến đợt phát hành
        public Guid? VoucherBatchId { get; set; }
        public VoucherBatchDto VoucherBatch { get; set; }
    }
}
