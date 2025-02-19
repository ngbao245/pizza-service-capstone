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
            TableStatusEnum? tableStatus = string.IsNullOrEmpty(request.Status)
                ? throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS)
                : Enum.TryParse(request.Status, true, out TableStatusEnum status)
                    ? status
                    : throw new BusinessException(BussinessErrorConstants.TableErrorConstant.INVALID_TABLE_STATUS);
            var result = await _tableService.UpdateAsync(
                request.Id!.Value,
                request.TableNumber,
                request.Capacity,
                tableStatus.Value,
                request.ZoneId);
        }
    }
}
