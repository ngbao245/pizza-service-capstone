namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class WorkshopPizzaRegisterDetailDto
    {
        public Guid Id { get; set; }

        public decimal AdditionalPrice { get; set; }

        public Guid OptionItemId { get; set; }

        public OptionItemDto OptionItem { get; set; }
    }
}
