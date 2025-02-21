using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.CloseTable
{
    public class CloseTableCommandHandler : IRequestHandler<CloseTableCommand>
    {
        private readonly ITableService _tableService;

        public CloseTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }
        public async Task Handle(CloseTableCommand request, CancellationToken cancellationToken)
        {
            await _tableService.CloseTable(request.Id!.Value);
        }
    }
}
