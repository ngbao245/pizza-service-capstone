using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
