using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class ZoneConfigration : IEntityTypeConfiguration<Zone>
	{
		public void Configure(EntityTypeBuilder<Zone> builder)
		{
			builder.ToTable(TableNames.Zone);
			builder.HasKey(x => x.Id);
            builder
    .HasIndex(x => x.Name)
    .IsUnique(); // Đánh unique index
        }
	}
}
