using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CancelMergeTable
{
    public class CancelMergeTableCommand : IRequest
    {
        public Guid TableMergeId { get; set; }
    }
}
