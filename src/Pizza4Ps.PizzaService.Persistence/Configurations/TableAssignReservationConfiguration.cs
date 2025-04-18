using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class TableAssignReservationConfiguration : IEntityTypeConfiguration<TableAssignReservation>
    {
        public void Configure(EntityTypeBuilder<TableAssignReservation> builder)
        {
            builder.ToTable(TableNames.TableAssignReservation);
            builder.HasKey(x => x.Id);

            builder.HasOne(s => s.Reservation)
                   .WithMany(x => x.TableAssignReservations)
                   .HasForeignKey(s => s.ReservationId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(s => s.Table)
                   .WithMany()
                   .HasForeignKey(s => s.TableId)
                   .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
