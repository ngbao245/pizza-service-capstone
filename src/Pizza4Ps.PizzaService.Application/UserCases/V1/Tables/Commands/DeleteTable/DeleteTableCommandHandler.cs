using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.DeleteTable
{
    public class DeleteTableCommandHandler : IRequestHandler<DeleteTableCommand>
    {
        ITableService _tableService;

        public DeleteTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }

        public async Task Handle(DeleteTableCommand request, CancellationToken cancellationToken)
        {
            await _tableService.DeleteAsync(request.Ids, request.isHardDelete);
        }
    }
}
