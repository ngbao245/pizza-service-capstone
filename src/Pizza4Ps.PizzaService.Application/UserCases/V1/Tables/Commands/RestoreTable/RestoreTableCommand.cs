using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.RestoreTable
{
    public class RestoreTableCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
