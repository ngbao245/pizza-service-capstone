using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdminManagers.Commands.CreateStaffAccount
{
    public class CreateStaffAccountCommand : IRequest
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StaffType { get; set; }
        public string Status { get; set; }
    }
}
