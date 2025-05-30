﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class FeedbackConfigration : IEntityTypeConfiguration<Feedback>
	{
		public void Configure(EntityTypeBuilder<Feedback> builder)
		{
			builder.ToTable(TableNames.FeedBack);
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Order)
				.WithMany()
				.HasForeignKey(x => x.OrderId);
		}
	}
}
