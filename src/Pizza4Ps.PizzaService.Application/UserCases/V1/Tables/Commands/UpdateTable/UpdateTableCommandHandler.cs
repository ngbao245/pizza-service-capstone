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

            // Parse string status into enum
            TableStatusEnum tableStatus = string.IsNullOrWhiteSpace(request.Status)
                ? throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS)
                : Enum.TryParse<TableStatusEnum>(request.Status, true, out var parsedStatus)
                    ? parsedStatus
                    : throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);

            await _tableService.UpdateAsync(
                request.Id.Value,
                request.Code,
                request.Capacity,
                tableStatus,
                request.ZoneId);
        }
    }
}
