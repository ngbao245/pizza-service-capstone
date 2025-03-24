using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
    {
        public void Configure(EntityTypeBuilder<Recipe> builder)
        {
            builder.ToTable(TableNames.Recipe);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Unit)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Quantity)
                .IsRequired();

            builder.HasOne(x => x.Ingredient)
                .WithMany(i => i.Recipes)
                .HasForeignKey(x => x.IngredientId);

            builder.HasOne(x => x.ProductSize)
                .WithMany(ps => ps.Recipes)
                .HasForeignKey(x => x.ProductSizeId);
        }
    }
}
