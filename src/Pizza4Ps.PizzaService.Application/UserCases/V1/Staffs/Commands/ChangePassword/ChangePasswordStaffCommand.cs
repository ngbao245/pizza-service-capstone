using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.ChangePassword
{
    public class ChangePasswordStaffCommand : IRequest
    {
        public Guid StaffId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
