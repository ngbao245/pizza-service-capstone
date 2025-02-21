using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.OpenTable
{
    public class OpenTableCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
