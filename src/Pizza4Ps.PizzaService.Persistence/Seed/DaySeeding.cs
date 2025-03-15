using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class DaySeeding : IEntityTypeConfiguration<Day>
    {
        public void Configure(EntityTypeBuilder<Day> builder)
        {
            builder.HasData(
                new Day
                {
                    Id = Guid.Parse("478fcc2b-4839-4fc2-baff-db273aa9e0b4"),
                    Name = "Thứ hai",
                },
                new Day
                {
                    Id = Guid.Parse("f8dec225-dbb2-4961-9be6-9f11eac723ab"),
                    Name = "Thứ ba",
                },
                new Day
                {
                    Id = Guid.Parse("24a0e861-15b0-4d60-ac54-adf5ee0f1ccd"),
                    Name = "Thứ tư",
                },
                new Day
                {
                    Id = Guid.Parse("1afe24bd-4d62-480b-a501-692bdd375bcb"),
                    Name = "Thứ năm",
                },
                new Day
                {
                    Id = Guid.Parse("93e1d6e5-b144-4099-be3c-833f7ef87fa3"),
                    Name = "Thứ sáu",
                },
                new Day
                {
                    Id = Guid.Parse("4c37288c-3a9c-4d6e-9565-4302a5a28669"),
                    Name = "Thứ bảy",
                },
                new Day
                {
                    Id = Guid.Parse("c6f2594b-71f8-46ff-9584-c62c2e02151e"),
                    Name = "Chủ nhật",
                }
            );
        }
    }
}
