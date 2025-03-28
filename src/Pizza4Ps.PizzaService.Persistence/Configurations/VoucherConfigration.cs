using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class VoucherConfigration : IEntityTypeConfiguration<Voucher>
    {
        public void Configure(EntityTypeBuilder<Voucher> builder)
        {
            builder.ToTable(TableNames.Voucher);
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Code)
                .IsUnique();

            builder.HasOne(x => x.VoucherBatch)
                .WithMany(x => x.Vouchers)
                .HasForeignKey(x => x.VoucherBatchId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
