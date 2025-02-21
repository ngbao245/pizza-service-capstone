using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.OpenTable
{
    public class OpenTableCommandHandler : IRequestHandler<OpenTableCommand>
    {
        private readonly ITableService _tableService;

        public OpenTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }
        public async Task Handle(OpenTableCommand request, CancellationToken cancellationToken)
        {
            await _tableService.OpenTable(request.Id);
        }
    }
}
