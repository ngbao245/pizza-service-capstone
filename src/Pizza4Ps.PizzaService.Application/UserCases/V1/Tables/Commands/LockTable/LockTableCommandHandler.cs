using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.LockTable
{
    public class LockTableCommandHandler : IRequestHandler<LockTableCommand>
    {
        private readonly ITableService _tableService;

        public LockTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }
        public async Task Handle(LockTableCommand request, CancellationToken cancellationToken)
        {
            await _tableService.LockTable(request.Id, request.Note);
        }
    }
}
