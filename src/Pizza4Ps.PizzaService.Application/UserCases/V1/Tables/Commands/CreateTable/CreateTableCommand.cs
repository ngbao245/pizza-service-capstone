using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CreateTable
{
    public class CreateTableCommand : IRequest<ResultDto<Guid>>
    {
        public string Code{ get; set; }
        public int Capacity { get; set; }
        public Guid ZoneId { get; set; }
    }
}
