using Pizza4Ps.PizzaService.Domain.Abstractions.Services.ServiceBase;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Abstractions.Services
{
    public interface IVoucherBatchService : IDomainService
    {
		Task<Guid> CreateAsync(string batchCode, string? description,
            DateTime startDate, DateTime endDate,
            DateTime issuedAt, int totalQuantity, decimal discountValue, DiscountTypeEnum discountType, decimal changePoint);
    }
}
