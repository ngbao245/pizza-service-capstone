using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Categories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Categories.Commands.CreateCategory
{
	public class CreateCategoryCommand : IRequest<CreateCategoryCommandResponse>
	{
		public Guid Id { get; set; }
		public CreateCategoryDto CreateCategoryDto { get; set; }
	}
}
