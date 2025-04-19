using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.MergeTable
{
    public class MergeTableCommand : IRequest
    {
        public List<Guid> TableIds { get; set; }

        public string GroupName { get; set; }
    }
}
