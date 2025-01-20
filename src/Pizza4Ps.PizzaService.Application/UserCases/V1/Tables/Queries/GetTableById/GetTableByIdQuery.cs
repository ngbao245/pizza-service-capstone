using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Queries.GetTableById
{
    public class GetTableByIdQuery : IRequest<TableDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
