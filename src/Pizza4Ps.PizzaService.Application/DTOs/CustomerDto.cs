using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }

        public string? FullName { get; set; }

        public string? Phone { get; set; }

        public string? Address { get; set; }

        public string? VerifiedCodeEmail { get; set; }

        public bool IsVerifiedEmail { get; set; }

        public bool? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Email { get; set; }
    }
}
