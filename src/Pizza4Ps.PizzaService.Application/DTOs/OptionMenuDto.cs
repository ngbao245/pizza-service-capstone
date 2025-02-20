namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class OptionMenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<OptionItemMenuDto> Items { get; set; } = new List<OptionItemMenuDto>();
    }
}
