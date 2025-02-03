using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkingTimes.Queries.GetWorkingTimeById
{
    public class GetWorkingTimeByIdQuery : IRequest<WorkingTimeDto>
	{
		public Guid Id { get; set; }
		public string includeProperties { get; set; } = "";
	}
}
