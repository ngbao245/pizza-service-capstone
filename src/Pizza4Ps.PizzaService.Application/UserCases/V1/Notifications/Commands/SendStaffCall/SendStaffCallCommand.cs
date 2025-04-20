using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Notifications.Commands.SendStaffCall
{
    public class SendStaffCallCommand : IRequest
    {
        public Guid TableId { get; set; }
        public string? Note { get; set; }
    }
}
