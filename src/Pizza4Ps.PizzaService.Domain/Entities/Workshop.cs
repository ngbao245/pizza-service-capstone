using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Workshop : EntityAuditBase<Guid>
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

        public WorkshopStatus WorkshopStatus { get; set; }  

        public long totalRegisteredParticipant { get; set; }

        public Guid? ZoneId { get; set; }

        public Zone Zone { get; set; }

        public string ZoneName { get; set; }

        public ICollection<WorkshopFoodDetail> WorkshopFoodDetails { get; set; }

        public ICollection<WorkshopRegister> WorkshopRegisters { get; set; }

        public Workshop()
        {
            
        }

        public Workshop(string name, string header,
            string description, string location,
            string organizer, string hotLineContact,
            DateTime workshopDate, DateTime startRegisterDate,
            DateTime endRegisterDate, decimal totalFee,
            int maxRegister, int maxPizzaPerRegister,
            int maxParticipantPerRegister, Guid zoneId, string zoneName)
        {
            Id = Guid.NewGuid();
            Name = name;
            Header = header;
            Description = description;
            Location = location;
            Organizer = organizer;
            HotLineContact = hotLineContact;
            WorkshopDate = workshopDate;
            StartRegisterDate = startRegisterDate;
            EndRegisterDate = endRegisterDate;
            TotalFee = totalFee;
            MaxRegister = maxRegister;
            MaxPizzaPerRegister = maxPizzaPerRegister;
            MaxParticipantPerRegister = maxParticipantPerRegister;
            ZoneId = zoneId;
            ZoneName = zoneName;
            WorkshopStatus = WorkshopStatus.Scheduled;
            totalRegisteredParticipant = 0;
        }

        public void AddWorkshopRegister()
        {
            totalRegisteredParticipant += 1;
        }
    }
}
