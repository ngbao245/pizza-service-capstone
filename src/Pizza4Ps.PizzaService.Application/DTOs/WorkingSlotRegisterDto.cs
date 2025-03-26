using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkingSlotRegisterDto
    {
        public Guid Id { get; set; }
        public DateTime WorkingDate { get; set; }
        public DateTime RegisterDate { get; set; }
        public string Status { get; set; }
        public Guid StaffId { get; set; }
        public Guid WorkingSlotId { get; set; }

        public virtual StaffDto Staff { get; set; }
        public virtual WorkingSlotDto WorkingSlot {  get; set; }  
    }
}
