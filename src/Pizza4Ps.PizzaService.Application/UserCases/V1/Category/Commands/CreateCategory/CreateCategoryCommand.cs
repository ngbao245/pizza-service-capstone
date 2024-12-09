using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Category.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
