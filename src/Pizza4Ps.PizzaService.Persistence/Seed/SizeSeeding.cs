using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class SizeSeeding : IEntityTypeConfiguration<Size>
    {
        public void Configure(EntityTypeBuilder<Size> builder)
        {
            builder.HasData(
                new Size
                {
                    Id = Guid.Parse("97f4da7b-6fee-4f69-9e6c-077a4dd684d3"),
                    Name = "S",
                    DiameterCm = 12,
                    Description = null
                },
                new Size
                {
                    Id = Guid.Parse("d6962d49-9ebe-405b-ac54-016b91eb6bdb"),
                    Name = "M",
                    DiameterCm = 16,
                    Description = null
                },
                new Size
                {
                    Id = Guid.Parse("876d378b-89a3-4c94-ba50-e7cbd53b7c88"),
                    Name = "L",
                    DiameterCm = 20,
                    Description = null
                }
            );
        }
    }
}
