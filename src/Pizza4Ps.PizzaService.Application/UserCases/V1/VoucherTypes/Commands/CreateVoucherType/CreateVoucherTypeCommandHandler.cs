using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Commands.CreateVoucherType
{
    public class CreateVoucherTypeCommandHandler : IRequestHandler<CreateVoucherTypeCommand, ResultDto<Guid>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherTypeService _voucherTypeService;

        public CreateVoucherTypeCommandHandler(IMapper mapper, IVoucherTypeService voucherTypeService)
        {
            _mapper = mapper;
            _voucherTypeService = voucherTypeService;
        }

        public async Task<ResultDto<Guid>> Handle(CreateVoucherTypeCommand request, CancellationToken cancellationToken)
        {
            var result = await _voucherTypeService.CreateAsync(
                request.Name,
                request.Description,
                request.TotalQuantity);
            return new ResultDto<Guid>
            {
                Id = result
            };
        }
    }
}
