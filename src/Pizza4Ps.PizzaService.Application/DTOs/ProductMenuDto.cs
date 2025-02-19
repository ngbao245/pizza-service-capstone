using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductMenuDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
        public ProductTypeEnum.ProductType ProductType { get; set; }
        public List<OptionMenuDto> Options { get; set; } = new List<OptionMenuDto>();
    }
}
