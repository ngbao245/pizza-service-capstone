using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
    }
}
