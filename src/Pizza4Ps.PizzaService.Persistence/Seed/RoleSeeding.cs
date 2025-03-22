using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Persistence.Seed
{
    public class RoleSeeding : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Id = Guid.Parse("a2a52be7-cbe7-4d40-bfcc-cfa7549ad415"),
                    Name = "Staff"
                },
                new Role
                {
                    Id = Guid.Parse("14fdb4d8-8d9f-4f83-a27b-19028ff03996"),
                    Name = "Chef",
                }
            );
        }
    }
}
