using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkshopRegisterById
{
    public class GetWorkshopRegisterByIdQuery : IRequest<WorkshopRegisterDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
