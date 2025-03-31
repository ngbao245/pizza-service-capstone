using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Notifications.Commands.SendStaffCall
{
    public class SendStaffCallCommandHandler : IRequestHandler<SendStaffCallCommand>
    {
        private readonly INotificationService _notificationService;
        private readonly ITableRepository _tableRepository;

        public SendStaffCallCommandHandler(ITableRepository tableRepository,
            INotificationService notificationService)
        {
            _notificationService = notificationService;
            _tableRepository = tableRepository;
        }
        public async Task Handle(SendStaffCallCommand request, CancellationToken cancellationToken)
        {
            var table = await _tableRepository.GetSingleByIdAsync(request.TableId, "Zone");
            if (table == null)
            {
                throw new BusinessException(BussinessErrorConstants.TableErrorConstant.TABLE_NOT_FOUND);
            }
            await _notificationService.SendStaffCallNotificationAsync(table.Code, table.Zone.Name);
        }
    }
}
