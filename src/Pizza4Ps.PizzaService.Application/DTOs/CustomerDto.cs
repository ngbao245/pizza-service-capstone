using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
	public class CustomerDto
	{
		public Guid Id { get; set; }
		public string FullName { get; set; }
		public string Phone { get; set; }

		public virtual ICollection<Booking> Bookings { get; set; }
	}
}
