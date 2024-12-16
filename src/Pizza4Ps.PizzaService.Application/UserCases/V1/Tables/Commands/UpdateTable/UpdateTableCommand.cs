using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Tables;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable
{
    public class UpdateTableCommand : IRequest<UpdateTableCommandResponse>
    {
        public Guid Id { get; set; }
        public UpdateTableDto UpdateTableDto { get; set; }
    }
}
