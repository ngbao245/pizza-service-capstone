using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand>
    {
        private readonly ITableService _tableService;

        public UpdateTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }

        public async Task Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {

            await _tableService.UpdateAsync(
                request.Id.Value,
                request.Code,
                request.Capacity,
                request.ZoneId);
        }
    }
}
