using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.LockTable
{
    public class LockTableCommand : IRequest
    {
        public Guid Id { get; set; }

        public string? Note { get; set; }
    }
}
