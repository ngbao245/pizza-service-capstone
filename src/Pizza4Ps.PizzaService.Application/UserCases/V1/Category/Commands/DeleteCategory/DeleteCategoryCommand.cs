using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.Commands;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : BaseDeleteCommand, IRequest
    {
        public List<Guid> Ids { get; set; }
    }
}
