using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopById
{
    public class GetWorkshopByIdQuery : IRequest<WorkshopDto>
    {
        public Guid Id { get; set; }
        public string includeProperties { get; set; } = "";
    }
}
