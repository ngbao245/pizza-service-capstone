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

        public string VoucherStatus { get; set; }
        // Liên kết đến đợt phát hành
        public Guid? VoucherBatchId { get; set; }
        public VoucherBatchDto VoucherBatch { get; set; }
        public bool IsUsed { get; set; }           // false: chưa sử dụng; true: đã sử dụng
    }
}
