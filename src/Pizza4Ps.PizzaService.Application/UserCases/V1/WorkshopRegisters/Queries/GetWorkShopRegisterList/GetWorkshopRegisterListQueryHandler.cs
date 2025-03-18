using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Queries.GetWorkShopRegisterList
{
    public class GetWorkshopRegisterListQueryHandler : IRequestHandler<GetWorkshopRegisterListQuery, PaginatedResultDto<WorkshopRegisterDto>>
    {
        private readonly IMapper _mapper;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;

        public GetWorkshopRegisterListQueryHandler(IMapper mapper, IWorkshopRegisterRepository workshopRegisterRepository)
        {
            _mapper = mapper;
            _workshopRegisterRepository = workshopRegisterRepository;
        }

        public async Task<PaginatedResultDto<WorkshopRegisterDto>> Handle(GetWorkshopRegisterListQuery request, CancellationToken cancellationToken)
        {
            var query = _workshopRegisterRepository.GetListAsNoTracking(
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.VoucherErrorConstant.VOUCHER_NOT_FOUND);
            var result = _mapper.Map<List<WorkshopRegisterDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<WorkshopRegisterDto>(result, totalCount);
        }
    }
}
