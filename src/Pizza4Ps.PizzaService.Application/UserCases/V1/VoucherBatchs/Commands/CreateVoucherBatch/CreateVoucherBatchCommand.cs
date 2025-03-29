using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Commands.CreateVoucherBatch
{
    public class CreateVoucherBatchCommand : IRequest<ResultDto<Guid>>
    {
        public string BatchCode { get; set; }         // Ví dụ: "SPRING2025"
        public string? Description { get; set; }       // Mô tả chiến dịch
        public DateTime StartDate { get; set; }       // Hiệu lực của voucher
        public DateTime EndDate { get; set; }         // Hết hạn của voucher
        public int TotalQuantity { get; set; }        // Tổng số voucher phát hành
        public decimal DiscountValue { get; set; }   // Số voucher chưa được claim
        public string DiscountType { get; set; }
    }
}
