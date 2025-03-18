using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopRegister : EntityAuditBase<Guid>
    {
        public Guid CustomerId { get; set; }

        public Customer Customer { get; set; }

        public Guid WorkshopId { get; set; }

        public Workshop Workshop { get; set; }

        public WorkshopRegisterStatus WorkshopRegisterStatus { get; set; }
        
        public DateTime RegisteredAt { get; set; }

        public int TotalParticipant { get; set; }

        public Guid? OrderId { get; set; }

        public Order Order { get; set; }
    }
}
