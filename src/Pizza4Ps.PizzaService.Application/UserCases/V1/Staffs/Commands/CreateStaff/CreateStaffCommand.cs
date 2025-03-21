using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<ResultDto<Guid>>
	{
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum StaffType { get; set; }
        public StaffStatusEnum Status { get; set; }
    }
}
