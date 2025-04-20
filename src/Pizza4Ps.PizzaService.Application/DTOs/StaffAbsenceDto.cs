using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class StaffAbsenceDto
    {
        public Guid Id { get; set; }
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }
        public DateOnly AbsentDate { get; set; }

        public virtual Staff Staff { get; set; }
        public virtual WorkingSlot WorkingSlot { get; set; }
    }
}
