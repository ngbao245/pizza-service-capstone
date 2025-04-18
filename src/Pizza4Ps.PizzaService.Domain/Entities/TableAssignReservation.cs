using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class TableAssignReservation : EntityAuditBase<Guid>
    {
        public Guid? ReservationId { get; set; }
        public Guid? TableId { get; set; }
        public Reservation Reservation { get; set; }
        public Table Table { get; set; }
    }
}
