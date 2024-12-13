using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.UpdateTable
{
    public class UpdateTableCommandHandler : IRequestHandler<UpdateTableCommand, UpdateTableCommandResponse>
    {
        private readonly ITableService _tableService;

        public UpdateTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }

        public async Task<UpdateTableCommandResponse> Handle(UpdateTableCommand request, CancellationToken cancellationToken)
        {
            var result = await _tableService.UpdateAsync(
                request.Id,
                request.UpdateTableDto.TableNumber,
                request.UpdateTableDto.Capacity,
                request.UpdateTableDto.Status,
                request.UpdateTableDto.ZoneId);
            return new UpdateTableCommandResponse
            {
                Id = result
            };
        }
    }
}
