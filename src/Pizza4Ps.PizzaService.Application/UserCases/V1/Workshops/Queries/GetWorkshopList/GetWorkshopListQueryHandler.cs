using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Queries.GetWorkshopList
{
    public class GetWorkshopListQueryHandler : IRequestHandler<GetWorkshopListQuery, PaginatedResultDto<WorkshopDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRepository _workshopRepository;

        public GetWorkshopListQueryHandler(IMapper mapper, IWorkshopRepository workshopRepository)
        {
            _mapper = mapper;
            _workshopRepository = workshopRepository;
        }

        public async Task<PaginatedResultDto<WorkshopDto>> Handle(GetWorkshopListQuery request, CancellationToken cancellationToken)
        {
            var query = _workshopRepository.GetListAsNoTracking(
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            var result = _mapper.Map<List<WorkshopDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WorkshopDto>(result, totalCount);
        }
    }
}
