using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.UpdateStaff
{
    public class UpdateStaffCommand : IRequest
	{
		public Guid? Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum.StaffType StaffType { get; set; }
        public StaffTypeEnum.StaffStatus Status { get; set; }
    }
}
