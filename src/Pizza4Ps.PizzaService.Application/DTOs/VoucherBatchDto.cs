using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;
using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class VoucherBatchDto
    {
        public Guid Id { get; set; }
        public string BatchCode { get; set; }         // Ví dụ: "SPRING2025"
        public string? Description { get; set; }       // Mô tả chiến dịch
        public DateTime StartDate { get; set; }       // Hiệu lực của voucher
        public DateTime EndDate { get; set; }         // Hết hạn của voucher
        public DateTime IssuedAt { get; set; }        // Thời gian tạo đợt voucher
        public int TotalQuantity { get; set; }        // Tổng số voucher phát hành
        public int RemainingQuantity { get; set; }
        public decimal DiscountValue { get; set; }   // Số voucher chưa được claim
        public string DiscountType { get; set; }

        // Quan hệ 1-n: Một đợt voucher có nhiều voucher
        public ICollection<VoucherDto> Vouchers { get; set; } = new List<VoucherDto>();
    }
}
