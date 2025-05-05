using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class VoucherBatch : EntityAuditBase<Guid>
    {
        public string BatchCode { get; set; }         // Ví dụ: "SPRING2025"
        public string? Description { get; set; }       // Mô tả chiến dịch
        public DateTime StartDate { get; set; }       // Hiệu lực của voucher
        public DateTime EndDate { get; set; }         // Hết hạn của voucher
        public DateTime IssuedAt { get; set; }        // Thời gian tạo đợt voucher
        public int TotalQuantity { get; set; }        // Tổng số voucher phát hành
        public int RemainingQuantity { get; set; }    // Số voucher chưa được claim
        public decimal ChangePoint { get; set; }     // Điểm đổi voucher
        public decimal DiscountValue { get; set; }   
        public DiscountTypeEnum DiscountType { get; set; }

        public bool IsValid { get; set; } = true; // Trạng thái của đợt voucher (còn hiệu lực hay không)
        // Quan hệ 1-n: Một đợt voucher có nhiều voucher
        public ICollection<Voucher> Vouchers { get; set; } = new List<Voucher>();   

        public VoucherBatch()
        {
        }

        public VoucherBatch(string batchCode, string? description,
            DateTime startDate, DateTime endDate,
            DateTime issuedAt, int totalQuantity,
            decimal discountValue, DiscountTypeEnum discountType, decimal changePoint)
        {
            Id = Guid.NewGuid();
            BatchCode = batchCode;
            Description = description;
            StartDate = startDate;
            EndDate = endDate;
            IssuedAt = issuedAt;
            TotalQuantity = totalQuantity;
            RemainingQuantity = totalQuantity;
            DiscountValue = discountValue;
            DiscountType = discountType;
            ChangePoint = changePoint;
            IsValid = true;
        }
        //public VoucherBatch(Guid id, string name, string description, int totalQuantity)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    TotalQuantity = ValidateTotalQuantity(totalQuantity);
        //}

        public void SetInvalid()
        {
            IsValid = false;
        }

        private int ValidateTotalQuantity(int totalQuantity)
        {
            if (totalQuantity <= 0)
            {
                throw new BusinessException(BussinessErrorConstants.VoucherBatchErrorConstant.TOTAL_QUANTITY_INVALID);
            }
            return totalQuantity;
        }
    }
}