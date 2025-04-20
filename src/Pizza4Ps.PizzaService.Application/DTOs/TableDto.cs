using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class TableDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public int Capacity { get; set; }
        public string Status { get; set; }
        public string? Note { get; set; }
        public Guid ZoneId { get; set; }
        public Guid? CurrentOrderId { get; set; }
        public Guid? CurrentReservationId { get; set; }
        public virtual OrderDto CurrentOrder { get; set; }
        public Guid? TableMergeId { get; set; }

        public string? TableMergeName { get; set; }

        public TableMergeDto TableMerge { get; set; }
        public virtual ReservationDto CurrentReservation { get; set; }
        public virtual ZoneDto Zone { get; set; }
    }
}
