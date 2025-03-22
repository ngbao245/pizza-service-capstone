using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Queries.GetRecipeById
{
    public class GetRecipeByIdQuery : IRequest<RecipeDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
