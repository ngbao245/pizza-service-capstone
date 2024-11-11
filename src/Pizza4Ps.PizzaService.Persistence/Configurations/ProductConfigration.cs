using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using StructureCodeSolution.Persistence.Constants;

namespace StructureCodeSolution.Persistence.Configurations
{
    internal class ProductConfigration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(TableNames.Product);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired(true)
                .HasMaxLength(200);
            builder.Property(x => x.Description).IsRequired(true)
                .HasMaxLength(200);
            builder.Property(x => x.Price).IsRequired(true)
                .HasDefaultValue(0);
            builder
                .Property(m => m.Price)
                .HasColumnType("decimal(18, 2)");  // Xác định kiểu cột là decimal với độ chính xác và thang đo.

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.Category.Id)
                .IsRequired();

        }
    }
}
