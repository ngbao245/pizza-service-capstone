using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

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
        public virtual ICollection<ProductSizeDto> ProductSizes { get; set; }
        public virtual ICollection<OptionDto> Options { get; set; }

        // Field mới: phân loại sản phẩm (master, single, child, combo)
        public string ProductRole { get; set; }

        public virtual ICollection<ProductDto> ChildProducts { get; set; } = new List<ProductDto>();

        public virtual ICollection<ProductComboItemDto> ComboItems { get; set; } = new List<ProductComboItemDto>();

    }
}
