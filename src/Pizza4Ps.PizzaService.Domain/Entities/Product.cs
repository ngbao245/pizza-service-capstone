using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Product : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public byte[]? Image { get; set; }
        public string? ImageUrl { get; set; } // URL ảnh trên Cloudinary
        public string? ImagePublicId { get; set; } // Public ID của ảnh trên Cloudinary
        public Guid CategoryId { get; set; }

        // Field mới: phân loại sản phẩm (master, single, child, combo)
        public ProductRoleEnum ProductRole { get; set; }

        // Quan hệ giữa sản phẩm master và sản phẩm child (ví dụ: các size khác nhau)
        public Guid? ParentProductId { get; set; }
        public virtual Product? ParentProduct { get; set; }
        public virtual ICollection<Product> ChildProducts { get; set; } = new List<Product>();

        public ProductTypeEnum? ProductType { get; set; }

        public ProductStatus ProductStatus { get; set; }

        public virtual Category Category { get; set; }
        public virtual ICollection<ProductOption> ProductOptions { get; set; } = new List<ProductOption>();
        public virtual ICollection<ProductComboSlot> ProductComboSlots { get; set; } = new List<ProductComboSlot>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();

        public Product()
        {
        }

        public Product(Guid id, string name, decimal price,
            byte[]? image, string? description,
            Guid categoryId, ProductTypeEnum? productType,
            string? imageUrl, string? imagePublicId, ProductRoleEnum productRole, Guid? parentProductId)
        {
            Id = id;
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
            Image = image;
            ImageUrl = imageUrl;
            ImagePublicId = imagePublicId;
            ProductRole = productRole;
            ParentProductId = parentProductId;
            ProductStatus = ProductStatus.Locked;
        }

        public void UpdateProduct(string name, decimal price, byte[]? image, string description, Guid categoryId, ProductTypeEnum productType, string? imageUrl, string? imagePublicId)
        {
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
            Image = image;
            if (imageUrl != null) ImageUrl = imageUrl;
            if (imagePublicId != null) ImagePublicId = imagePublicId;
        }
        public void UpdateProductStatus(ProductStatus productStatus)
        {
            ProductStatus = productStatus;
        }
        private string SetName(string name)
        {
            //    if (Name == null) throw new ValidationException("Invalid name");
            return name;
        }

        public void UpdateImage(string? imageUrl, string? imagePublicId)
        {
            if (imageUrl != null)
            {
                ImageUrl = imageUrl;
            }
            if (imagePublicId != null)
            {
                ImagePublicId = imagePublicId;
            }
        }
    }
}
