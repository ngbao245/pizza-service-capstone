using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Recipe.Commands.CreateRecipe
{
    public class CreateRecipeCommand : IRequest<ResultDto<Guid>>
    {
        public string Unit { get; set; }
        public string Name { get; set; }
    }
}
