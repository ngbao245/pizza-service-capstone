using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopDto
    {
        public Guid Id { get; set; }

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

        public string WorkshopStatus { get; set; }

        public Guid? ZoneId { get; set; }

        public ZoneDto Zone { get; set; }

        public string ZoneName { get; set; }

        public List<WorkshopFoodDetailDto> WorkshopFoodDetails { get; set; }
        //public ICollection<WorkshopRegister> WorkshopRegisters { get; set; }
    }
}
