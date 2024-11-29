using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Customer : EntityAuditBase<Guid>
    {
        public string FullName { get; set; }
        public int Phone { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        private Customer()
        {
        }

        public Customer(string fullName, int phone)
        {
            FullName = fullName;
            Phone = phone;
        }
    }
}
