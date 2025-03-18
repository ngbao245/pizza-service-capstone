using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Vouchers.Queries.GetListVoucherIgnoreQueryFilter
{
    public class GetListVoucherIgnoreQueryFilterQuery : PaginatedQuery<PaginatedResultDto<VoucherDto>>
    {
        public bool IsDeleted { get; set; } = false;
        public string? Code { get; set; }
        public DiscountTypeEnum? DiscountType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public Guid? VoucherTypeId { get; set; }
    }
}
