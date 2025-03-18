using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	internal class ProductConfigration : IEntityTypeConfiguration<Product>
	{
		public void Configure(EntityTypeBuilder<Product> builder)
		{
			builder.ToTable(TableNames.Product);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Price)
			.HasColumnType("decimal(18, 2)"); // Xác định kiểu cột là decimal với độ chính xác và thang đo.

			builder.HasOne(x => x.Category)
				.WithMany()
				.HasForeignKey(x => x.CategoryId);
        }
	}
}
