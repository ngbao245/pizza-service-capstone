using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class OrderItemConfigration : IEntityTypeConfiguration<OrderItem>
	{
		public void Configure(EntityTypeBuilder<OrderItem> builder)
		{
			builder.ToTable(TableNames.OrderItem);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Price)
				.HasColumnType("decimal(18,2)");

			builder.Property(x => x.TotalPrice)
				.HasColumnType("decimal(18, 2)"); // Xác định kiểu cột là decimal với độ chính xác và thang đo.

			builder.HasOne(x => x.Order)
				.WithMany(x => x.OrderItems)
				.HasForeignKey(x => x.OrderId);

			builder.HasOne(x => x.Product)
				.WithMany()
				.HasForeignKey(x => x.ProductId);
        }
	}
}
