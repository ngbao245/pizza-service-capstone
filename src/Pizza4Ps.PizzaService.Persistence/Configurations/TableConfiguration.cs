using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class TableConfigration : IEntityTypeConfiguration<Table>
	{
		public void Configure(EntityTypeBuilder<Table> builder)
		{
			builder.ToTable(TableNames.Table);
			builder.HasKey(x => x.Id);

			builder.HasOne(x => x.Zone)
				.WithMany(x => x.Tables)
				.HasForeignKey(x => x.ZoneId);

			builder.HasOne(x => x.CurrentOrder)
				.WithMany()
				.HasForeignKey(x => x.CurrentOrderId);
        }
	}
}
