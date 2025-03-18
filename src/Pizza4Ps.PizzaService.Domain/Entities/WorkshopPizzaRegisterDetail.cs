using Pizza4Ps.PizzaService.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class WorkshopPizzaRegisterDetail : EntityAuditBase<Guid>
    {
        public Guid WorkshopPizzaRegisterId { get; set; }

        public WorkshopPizzaRegister WorkshopPizzaRegister { get; set; }

        public decimal AdditionalPrice { get; set; }

        public Guid OptionItemId { get;set; }

        public OptionItem OptionItem { get; set; }
        public WorkshopPizzaRegisterDetail()
        {
            
        }

        public WorkshopPizzaRegisterDetail(Guid workshopPizzaRegisterId, decimal additionalPrice, Guid optionItemId)
        {
            Id = Guid.NewGuid();
            WorkshopPizzaRegisterId = workshopPizzaRegisterId;
            AdditionalPrice = additionalPrice;
            OptionItemId = optionItemId;
        }
    }
}
