using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Commands.CreateVoucherBatch
{
    public class CreateVoucherBatchCommandHandler : IRequestHandler<CreateVoucherBatchCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherBatchService _voucherBatchService;

        public CreateVoucherBatchCommandHandler(IMapper mapper, IVoucherBatchService voucherBatchService)
        {
            _mapper = mapper;
            _voucherBatchService = voucherBatchService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateVoucherBatchCommand request, CancellationToken cancellationToken)
        {
            if (!Enum.TryParse(request.DiscountType, true, out DiscountTypeEnum discountType))
            {
                throw new BusinessException(BussinessErrorConstants.VoucherBatchErrorConstant.VOUCHER_BATCH_INVALID_DISCOUNT_TYPE);
            }
            var result = await _voucherBatchService.CreateAsync(request.BatchCode,
                request.Description,
                startDate: request.StartDate,
                endDate: request.EndDate,
                DateTime.Now,
                totalQuantity: request.TotalQuantity,
                discountType: discountType,
                discountValue: request.DiscountValue,
                changePoint: request.ChangePoint);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
