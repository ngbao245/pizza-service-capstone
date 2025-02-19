using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<ResultDto<Guid>>
    {
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public TableTypeEnum Status { get; set; } = TableTypeEnum.Closed;
        public Guid ZoneId { get; set; }
    }
}
