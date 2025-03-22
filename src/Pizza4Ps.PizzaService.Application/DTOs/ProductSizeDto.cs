namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductSizeDto
    {
        public string ProductId { get; set; }
        public string RecipeId { get; set; }
        public string SizeId { get; set; }

        public virtual RecipeDto Recipe { get; set; }
        public virtual SizeDto Size { get; set; }
        public virtual ICollection<ProductDto> Products { get; set; }
    }
}
