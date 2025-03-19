using System.Xml.Linq;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Customer : EntityAuditBase<Guid>
    {
        public string? FullName { get; set; }
        
        public string? Phone { get; set; }

        public string? Address { get;set; }

        public bool? Gender { get;set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }

        public Guid? AppUserCustomerId { get; set; }
        
        public virtual AppUserCustomer AppUserCustomer { get; set; }    

        private Customer()
        {
        }

        public Customer(Guid id,string fullName, string phone)
        {
            Id = id;
            FullName = fullName;
            Phone = phone;
        }

        public Customer(string? fullName, string? phone, string? address, bool? gender, DateTime? dateOfBirth, string? email, Guid? appUserCustomerId)
        {
            FullName = fullName;
            Phone = phone;
            Address = address;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            Email = email;
            AppUserCustomerId = appUserCustomerId;
        }

        public void SetAppUserCustomerId(Guid? appUserCustomerId)
        {
            AppUserCustomerId = appUserCustomerId;
        }

        public void UpdateCustomer(string fullName, string phone)
		{
			FullName = fullName;
			Phone = phone;
		}
	}
}
