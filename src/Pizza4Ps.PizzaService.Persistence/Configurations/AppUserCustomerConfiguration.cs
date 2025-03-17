using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class AppUserCustomerConfiguration : IEntityTypeConfiguration<AppUserCustomer>
    {
        public void Configure(EntityTypeBuilder<AppUserCustomer> builder)
        {
            builder.ToTable(TableNames.AppUserCustomer);
            builder.HasKey(x => x.Id);
        }
    }
}
