using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class VoucherBatch : EntityAuditBase<Guid>
    {
        public Guid Id { get; set; }
        public string BatchCode { get; set; }         // Ví dụ: "SPRING2025"
        public string Description { get; set; }       // Mô tả chiến dịch
        public DateTime StartDate { get; set; }       // Hiệu lực của voucher
        public DateTime EndDate { get; set; }         // Hết hạn của voucher
        public DateTime IssuedAt { get; set; }        // Thời gian tạo đợt voucher
        public int TotalQuantity { get; set; }        // Tổng số voucher phát hành
        public int RemainingQuantity { get; set; }
        public decimal DiscountValue { get; set; }   // Số voucher chưa được claim

        // Quan hệ 1-n: Một đợt voucher có nhiều voucher
        public ICollection<Voucher> Vouchers { get; set; }     

        public VoucherBatch()
        {
        }

        //public VoucherBatch(Guid id, string name, string description, int totalQuantity)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    TotalQuantity = ValidateTotalQuantity(totalQuantity);
        //}

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