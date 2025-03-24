using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterByCode
{
    public class GetWorkshopRegisterByCodeCommand : IRequest<WorkshopRegisterDto>
    {
        public string Code { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
