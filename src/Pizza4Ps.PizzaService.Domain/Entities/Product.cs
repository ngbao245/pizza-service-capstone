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
        public Guid CategoryId { get; set; }
        public ProductTypeEnum ProductType { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<Option> Options { get; set; }

        public Product()
        {
        }

        public Product(Guid id, string name, decimal price, byte[]? image, string description, Guid categoryId, ProductTypeEnum productType)
        {
            Id = Id;
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
            Image = image;
        }

        public void UpdateProduct(string name, decimal price, byte[]? image, string description, Guid categoryId, ProductTypeEnum productType)
        {
            Name = SetName(name);
            Price = price;
            Description = description;
            CategoryId = categoryId;
            ProductType = productType;
            Image = image;
        }
        private string SetName(string name)
        {
            //    if (Name == null) throw new ValidationException("Invalid name");
            return name;
        }
    }
}
