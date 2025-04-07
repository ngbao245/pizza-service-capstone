using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Orders.Commands.ApplyVoucher
{
    public class ApplyVoucherCommandHandler : IRequestHandler<ApplyVoucherCommand>
    {
        private readonly IVoucherRepository _voucherRepository;

        public ApplyVoucherCommandHandler(IUnitOfWork unitOfWork,
            IVoucherRepository voucherRepository,
            IOrderVoucherRepository orderVoucherRepository,
            IOrderRepository orderRepository)
        {
            _voucherRepository = voucherRepository;
        }
        public Task Handle(ApplyVoucherCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
