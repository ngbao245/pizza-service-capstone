using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.UpdateStaff
{
    public class UpdateStaffCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string? Password { get; set; }
        public StaffTypeEnum StaffType { get; set; }
        public StaffStatusEnum Status { get; set; }
    }
}
