using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest
    {
        public Guid? Id { get; set; }
        public int TableNumber { get; set; }
        public int Capacity { get; set; }
        public TableTypeEnum Status { get; set; } = TableTypeEnum.Available;
        public Guid ZoneId { get; set; }
    }
}
