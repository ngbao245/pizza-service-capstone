using MediatR;
using Microsoft.AspNetCore.Http;
using Pizza4Ps.PizzaService.Application.Abstractions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.CreateProductWithCombo
{
    public class CreateProductWithComboCommand : IRequest<ResultDto<Guid>>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IFormFile? file { get; set; }
        public string? Description { get; set; }
        public Guid CategoryId { get; set; }
        public string ComboSlots { get; set; }
    }
    public class ComboSlotModel
    {
        public string SlotName { get; set; }
        public List<ComboSlotItemModel> ComboSlotItems { get; set; }
    }

    public class ComboSlotItemModel
    {
        public Guid ProductId { get; set; }
        public decimal ExtraPrice { get; set; }
    }
}
