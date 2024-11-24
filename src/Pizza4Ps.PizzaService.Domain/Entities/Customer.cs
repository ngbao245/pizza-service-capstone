using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Customer : EntityAuditBase<Guid>
    {
        public string FullName { get; set; }
        public int PhoneNumber { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        private Customer()
        {
        }

        public Customer(Guid id, string fullName, int phoneNumber)
        {
            Id = id;
            FullName = fullName;
            PhoneNumber = phoneNumber;
        }
    }
}
