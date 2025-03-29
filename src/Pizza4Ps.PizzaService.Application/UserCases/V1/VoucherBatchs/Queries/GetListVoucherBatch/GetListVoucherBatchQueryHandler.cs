using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.VoucherBatchs.Queries.GetListVoucherBatch
{
    public class GetListVoucherBatchQueryHandler : IRequestHandler<GetListVoucherBatchQuery, PaginatedResultDto<VoucherBatchDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVoucherBatchRepository _voucherBatchRepository;

        public GetListVoucherBatchQueryHandler(IMapper mapper, IVoucherBatchRepository voucherBatchRepository)
        {
            _mapper = mapper;
            _voucherBatchRepository = voucherBatchRepository;
        }

        public async Task<PaginatedResultDto<VoucherBatchDto>> Handle(GetListVoucherBatchQuery request, CancellationToken cancellationToken)
        {
            var query = _voucherBatchRepository.GetListAsNoTracking(
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();

            var result = _mapper.Map<List<VoucherBatchDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<VoucherBatchDto>(result, totalCount);
        }
    }
}
