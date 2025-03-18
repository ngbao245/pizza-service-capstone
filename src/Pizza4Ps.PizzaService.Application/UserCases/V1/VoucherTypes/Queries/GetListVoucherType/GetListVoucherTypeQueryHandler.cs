using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherTypes.Queries.GetListVoucherType
{
    public class GetListVoucherTypeQueryHandler : IRequestHandler<GetListVoucherTypeQuery, PaginatedResultDto<VoucherTypeDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherTypeRepository _VoucherTypeRepository;

        public GetListVoucherTypeQueryHandler(IMapper mapper, IVoucherTypeRepository VoucherTypeRepository)
        {
            _mapper = mapper;
            _VoucherTypeRepository = VoucherTypeRepository;
        }

        public async Task<PaginatedResultDto<VoucherTypeDto>> Handle(GetListVoucherTypeQuery request, CancellationToken cancellationToken)
        {
            var query = _VoucherTypeRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (request.TotalQuantity == null || x.TotalQuantity == request.TotalQuantity),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherTypeErrorConstant.VOUCHER_TYPE_NOT_FOUND);
            var result = _mapper.Map<List<VoucherTypeDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<VoucherTypeDto>(result, totalCount);
        }
    }
}
