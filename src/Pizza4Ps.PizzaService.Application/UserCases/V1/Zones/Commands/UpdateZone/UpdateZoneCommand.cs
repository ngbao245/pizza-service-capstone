using MediatR;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Commands.UpdateZone
{
    public class UpdateZoneCommand : IRequest
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
        public string Description { get; set; }
        public ZoneTypeEnum Status { get; set; } = ZoneTypeEnum.Available;
    }
}
