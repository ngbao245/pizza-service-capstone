using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

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
            var result = await _tableService.UpdateAsync(
                request.Id!.Value,
                request.TableNumber,
                request.Capacity,
                request.Status,
                request.ZoneId);
        }
    }
}
