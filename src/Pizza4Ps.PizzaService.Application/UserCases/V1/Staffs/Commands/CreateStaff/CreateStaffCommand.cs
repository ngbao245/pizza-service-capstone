using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.CreateStaff
{
    public class CreateStaffCommand : IRequest<ResultDto<Guid>>
	{
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum.StaffType StaffType { get; set; }
        public StaffTypeEnum.StaffStatus Status { get; set; }
    }
}
