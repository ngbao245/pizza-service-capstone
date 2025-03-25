using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Staff : EntityAuditBase<Guid>
    {
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public StaffTypeEnum StaffType { get; set; }
        public StaffStatusEnum Status { get; set; }

        public Guid? AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        public Staff()
        {
        }

        public Staff(Guid id, string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
            Email = email;
            StaffType = staffType;
            Status = status;
        }

        public void UpdateStaff(string fullName, string phone, string email, StaffTypeEnum staffType, StaffStatusEnum status)
        {
            FullName = fullName;
            Phone = phone;
            Email = email;
            StaffType = staffType;
            Status = status;
        }
    }
}
