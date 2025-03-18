namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class SizeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int DiameterCm { get; set; }
        public string? Description { get; set; }
    }
}
