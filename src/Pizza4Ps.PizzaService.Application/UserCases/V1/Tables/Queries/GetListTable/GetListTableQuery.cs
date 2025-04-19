using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetListTable
{
    public class GetListTableQuery : PaginatedQuery<PaginatedResultDto<TableDto>>
    {
        public string? Code{ get; set; }
        public int? Capacity { get; set; }
        public string? Status { get; set; }
        public Guid? ZoneId { get; set; }
        public Guid? CurrentOrderId { get; set; }
        public Guid? TableMergeId { get; set; }
    }
}
