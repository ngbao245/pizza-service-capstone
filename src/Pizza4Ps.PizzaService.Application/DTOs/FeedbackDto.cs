namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class FeedbackDto
    {
        public Guid Id { get; set; }
        public int Rating { get; set; }
        public string? Comments { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid OrderId { get; set; }

        public virtual OrderDto Order { get; set; }
    }
}
