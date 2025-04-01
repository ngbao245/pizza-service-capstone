using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Ingredients.Commands.DeleteIngredient
{
    public class DeleteIngredientCommand : IRequest
    {
        public List<Guid> Ids { get; set; }
        public bool isHardDelete { get; set; }
    }
}
