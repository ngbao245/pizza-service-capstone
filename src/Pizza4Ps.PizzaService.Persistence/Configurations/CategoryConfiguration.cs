using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{

    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable(TableNames.Category);
            builder.HasKey(x => x.Id);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .IsRequired();
        }
    }
}
