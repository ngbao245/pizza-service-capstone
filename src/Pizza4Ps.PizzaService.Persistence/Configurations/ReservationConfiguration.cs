using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
	public class BookingConfigration : IEntityTypeConfiguration<Reservation>
	{
		public void Configure(EntityTypeBuilder<Reservation> builder)
		{
			builder.ToTable(TableNames.Reservation);
			builder.HasKey(x => x.Id);
            builder.HasOne(x => x.Customer)
                .WithMany()
                .HasForeignKey(x => x.CustomerId);

        }
    }
}
