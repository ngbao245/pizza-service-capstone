using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CreateWorkshopRegister
{
    public class CreateWorkshopRegisterCommand : IRequest<ResultDto<Guid>>
    {
        public string CustomerName { get; set; }

        public string PhoneNumber{ get; set; }

        public string PhoneOtp { get; set; }

        public Guid WorkshopId { get; set; }

        public int TotalParticipant { get; set; }

        public string Email { get; set; }

        public List<CreateWorkshopPizzaRegisterCommand> Products { get;set; }
    }
    // Command đăng ký pizza (cấp 2)
    public class CreateWorkshopPizzaRegisterCommand
    {
        public Guid ProductId { get; set; }
        public List<Guid> OptionItemIds { get; set; }
    }
}
