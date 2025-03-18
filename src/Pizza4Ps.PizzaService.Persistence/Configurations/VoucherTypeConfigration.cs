using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class VoucherTypeConfigration : IEntityTypeConfiguration<VoucherType>
    {
        public void Configure(EntityTypeBuilder<VoucherType> builder)
        {
            builder.ToTable(TableNames.Voucher);
            builder.HasKey(x => x.Id);
        }
    }
}
