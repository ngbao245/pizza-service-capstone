using MediatR;
using Microsoft.EntityFrameworkCore.Metadata;
using Pizza4Ps.PizzaService.Application.UserCases.V1.Staff.Commands.RestoreStaff;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Tables.Commands.RestoreTable
{
    public class RestoreTableCommandHandler : IRequestHandler<RestoreTableCommand>
    {
        private readonly ITableService _tableService;

        public RestoreTableCommandHandler(ITableService tableService)
        {
            _tableService = tableService;
        }

        public async Task Handle(RestoreTableCommand request, CancellationToken cancellationToken)
        {
            await _tableService.RestoreAsync(request.Ids);
        }
    }
}
