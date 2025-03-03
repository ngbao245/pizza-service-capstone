using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class BookingSlotConfiguration : IEntityTypeConfiguration<BookingSlot>
    {
        public void Configure(EntityTypeBuilder<BookingSlot> builder)
        {
            builder.ToTable(TableNames.BookingSlot);
            builder.HasKey(x => x.Id);
        }
    }
}
