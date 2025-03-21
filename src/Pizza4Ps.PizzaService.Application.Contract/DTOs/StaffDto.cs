using System.Text.Json.Serialization;

namespace Pizza4Ps.PizzaService.Application.Contract.DTOs
{
    public class StaffDto
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string StaffType { get; set; }
        public int Status { get; set; }
    }
}
