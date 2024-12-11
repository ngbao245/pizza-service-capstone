using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
