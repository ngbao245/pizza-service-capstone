using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Persistence.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class ProductSizeConfiguration : IEntityTypeConfiguration<ProductSize>
    {
        public void Configure(EntityTypeBuilder<ProductSize> builder)
        {
            builder.ToTable(TableNames.ProductSize);
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductSizes)
                .HasForeignKey(x => x.ProductId);

            builder.HasMany(x => x.Recipes)
              .WithOne(x => x.ProductSize)
              .HasForeignKey(x => x.ProductSizeId);
        }
    }
}
