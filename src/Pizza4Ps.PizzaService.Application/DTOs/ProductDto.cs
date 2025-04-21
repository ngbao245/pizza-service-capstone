using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageUrl { get; set; } // URL ảnh trên Cloudinary
        public string? ImagePublicId { get; set; } // Public ID của ảnh trên Cloudinary
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string ProductType { get; set; }
        public virtual CategoryDto Category { get; set; }
        public virtual ICollection<ProductOptionDto> ProductOptions { get; set; }

        // Field mới: phân loại sản phẩm (master, single, child, combo)
        public string ProductRole { get; set; }
        public string ProductStatus { get; set; }

        public virtual ICollection<ProductDto> ChildProducts { get; set; } = new List<ProductDto>();

        public virtual ICollection<ProductComboSlotDto> ProductComboSlots { get; set; } = new List<ProductComboSlotDto>();
        public virtual ICollection<RecipeDto> Recipes { get; set; } = new List<RecipeDto>();
    }
}
