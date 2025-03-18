using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
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

            builder.HasOne(x => x.Ingredient)
                .WithMany(x => x.Recipes)
                .HasForeignKey(x => x.IngredientId);
        }
    }
}
