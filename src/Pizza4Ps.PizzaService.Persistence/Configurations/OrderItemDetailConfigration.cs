﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class OrderItemDetailConfigration : IEntityTypeConfiguration<OrderItemDetail>
	{
		public void Configure(EntityTypeBuilder<OrderItemDetail> builder)
		{
			builder.ToTable(TableNames.OrderItemDetail);
			builder.HasKey(x => x.Id);

			builder.Property(x => x.AdditionalPrice)
				.HasColumnType("decimal(18, 2)");


			builder.HasOne(x => x.OrderItem)
				.WithMany(x => x.OrderItemDetails)
				.HasForeignKey(x => x.OrderItemId);
        }
	}
}
