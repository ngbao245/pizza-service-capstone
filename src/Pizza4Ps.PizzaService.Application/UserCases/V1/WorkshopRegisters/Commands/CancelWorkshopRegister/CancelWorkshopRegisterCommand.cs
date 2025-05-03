using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CancelWorkshopRegister
{
    public class CancelWorkshopRegisterCommand : IRequest
    {
        public Guid? WorkshopRegisterId { get; set; }
        public string? Reason { get; set; } // Lý do hủy đăng ký
    }
}
