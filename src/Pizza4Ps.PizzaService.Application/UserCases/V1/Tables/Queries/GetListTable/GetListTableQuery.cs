using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQuery : PaginatedQuery<PaginatedResultDto<TableDto>>
    {
        public int? TableNumber { get; set; }
        public int? Capacity { get; set; }
        public string? Status { get; set; }
        public Guid? ZoneId { get; set; }
    }
}
