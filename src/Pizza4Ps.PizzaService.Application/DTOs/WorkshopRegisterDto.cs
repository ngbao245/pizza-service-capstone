namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopRegisterDto
    {
        public Guid Id { get; set; }    

        public Guid CustomerId { get; set; }

        public CustomerDto Customer { get; set; }

        public Guid WorkshopId { get; set; }

        public WorkshopDto Workshop { get; set; }

        public string WorkshopRegisterStatus { get; set; }

        public DateTime RegisteredAt { get; set; }

        public int TotalParticipant { get; set; }

        public Guid? OrderId { get; set; }

        public OrderDto Order { get; set; }

        public List<WorkshopPizzaRegisterDto> WorkshopPizzaRegisters { get; set; }
    }
}
