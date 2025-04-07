using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CreateWorkshop
{
    public class CreateWorkshopCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Organizer { get; set; }

        public string HotLineContact { get; set; }

        public DateTime WorkshopDate { get; set; }

        public DateTime StartRegisterDate { get; set; }

        public DateTime EndRegisterDate { get; set; }

        public decimal TotalFee { get; set; }

        public int MaxRegister { get; set; }

        public int MaxPizzaPerRegister { get; set; }

        public int MaxParticipantPerRegister { get; set; }

        public List<Guid> ProductIds { get; set; }

        public Guid ZoneId { get; set; }
    }
}
