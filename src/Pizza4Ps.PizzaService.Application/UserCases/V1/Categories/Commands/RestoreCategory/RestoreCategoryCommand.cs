using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.RestoreCategory
{
    public class RestoreCategoryCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
