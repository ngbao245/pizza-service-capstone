using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CloseTable
{
    public class CloseTableCommand : IRequest
    {
        public Guid? Id { get; set; }
    }
}
