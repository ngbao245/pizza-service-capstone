namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class AdditionalFeeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public Guid OrderId { get; set; }
    }
}
