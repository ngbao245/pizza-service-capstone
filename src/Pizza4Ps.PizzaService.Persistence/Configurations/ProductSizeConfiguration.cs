using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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

            builder.HasOne(ps => ps.Products)
                   .WithMany()
                   .HasForeignKey(ps => ps.ProductId);

            builder.HasOne(ps => ps.Recipe)
                   .WithMany()
                   .HasForeignKey(ps => ps.RecipeId);

            builder.HasOne(ps => ps.Size)
                   .WithMany()
                   .HasForeignKey(ps => ps.SizeId);
        }
    }
}
