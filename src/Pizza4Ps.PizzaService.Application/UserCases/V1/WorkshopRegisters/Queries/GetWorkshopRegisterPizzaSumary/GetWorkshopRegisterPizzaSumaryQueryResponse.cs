using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterPizzaSumary
{
    public class GetWorkshopRegisterPizzaSumaryQueryResponse
    {
        public string ProductName { get; set; }

        public Guid? ProductId { get; set; }

        public ProductDto Product { get; set; }

        public int TotalQuantity { get; set; }
    }
}
