using MediatR;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.UpdateWorkshop
{
    public class UpdateWorkshopCommand : IRequest
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Header { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public string Organizer { get; set; }

        public string HotLineContact { get; set; }
    }
}
