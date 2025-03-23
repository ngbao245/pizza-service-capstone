using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthCustomer.Commands.RegisterCustomer
{
    public class RegisterCustomerCommand : IRequest
    {
        public string UserName { get; set; }

        public string Password { get;set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string Email { get; set; }
    }
}
