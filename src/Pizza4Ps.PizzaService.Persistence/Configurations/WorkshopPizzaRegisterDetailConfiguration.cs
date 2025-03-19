using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence.Constants;

namespace Pizza4Ps.PizzaService.Persistence.Configurations
{
    public class WorkshopPizzaRegisterDetailConfiguration : IEntityTypeConfiguration<WorkshopPizzaRegisterDetail>
    {
        public void Configure(EntityTypeBuilder<WorkshopPizzaRegisterDetail> builder)
        {
            builder.ToTable(TableNames.WorkshopPizzaRegisterDetail);
            builder.HasKey(x => x.Id);


            builder.HasOne(x => x.WorkshopPizzaRegister)
                .WithMany(x => x.WorkshopPizzaRegisterDetails)
                .HasForeignKey(x => x.WorkshopPizzaRegisterId);

            builder.HasOne(x => x.OptionItem)
                .WithMany()
                .HasForeignKey(x => x.OptionItemId);
        }
    }
}
