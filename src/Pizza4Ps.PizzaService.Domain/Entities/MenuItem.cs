using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class MenuItem : EntityAuditBase<Guid>
    {
        public string MenuItemName { get; set; }
        public MenuItemTypeEnum MenuItemStatus { get; set; }
        public string MenuItemDescription { get; set; }
        public string ImageUrl { get; set; }

    }
}
