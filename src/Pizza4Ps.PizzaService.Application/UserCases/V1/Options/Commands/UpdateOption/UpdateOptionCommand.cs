using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Options.Commands.UpdateOption
{
    public class UpdateOptionCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
