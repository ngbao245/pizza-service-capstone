using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Services
{
    public class VoucherBatchService : DomainService, IVoucherBatchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IVoucherRepository _voucherRepository;
        private readonly IVoucherBatchRepository _voucherBatchRepository;

        public VoucherBatchService(IUnitOfWork unitOfWork, IVoucherBatchRepository voucherBatchRepository,
            IVoucherRepository voucherRepository)
        {
            _unitOfWork = unitOfWork;
            _voucherRepository = voucherRepository;
            _voucherBatchRepository = voucherBatchRepository;
        }

        public async Task<Guid> CreateAsync(string batchCode, string? description,
            DateTime startDate, DateTime endDate,
            DateTime issuedAt, int totalQuantity, decimal discountValue, DiscountTypeEnum discountType, decimal changePoint)
        {
            var batch = new VoucherBatch(batchCode: batchCode,
                description: description,
                startDate: startDate,
                endDate: endDate,
                issuedAt: issuedAt,
                totalQuantity: totalQuantity,
                discountValue: discountValue,
                discountType: discountType,
                changePoint: changePoint);
            // Sinh đồng loạt các voucher
            for (int i = 0; i < totalQuantity; i++)
            {
                var voucher = new Voucher(
                    voucherBatchId: batch.Id,
                    code: GenerateUniqueVoucherCode(),
                    discountType: discountType,
                    discountValue: discountValue);
                batch.Vouchers.Add(voucher);
            }

            _voucherBatchRepository.Add(batch);
            await _unitOfWork.SaveChangeAsync();
            return batch.Id;
        }
        /// <summary>
        /// Sinh mã voucher ngẫu nhiên dựa trên Guid (8 ký tự) và kết hợp với batchCode
        /// </summary>
        private string GenerateUniqueVoucherCode()
        {
            // Lấy 8 ký tự đầu của Guid (dạng hex) và chuyển thành chữ in hoa
            string randomPart = Guid.NewGuid().ToString("N").Substring(0, 8).ToUpper();
            return randomPart;
        }

    }
}
