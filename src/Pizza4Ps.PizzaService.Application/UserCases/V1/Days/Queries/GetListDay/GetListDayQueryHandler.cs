using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Days.Queries.GetListDay
{
    public class GetListDayQueryHandler : IRequestHandler<GetListDayQuery, PaginatedResultDto<DayDto>>
    {
        private readonly IMapper _mapper;
        private readonly IDayRepository _DayRepository;

        public GetListDayQueryHandler(IMapper mapper, IDayRepository DayRepository)
        {
            _mapper = mapper;
            _DayRepository = DayRepository;
        }

        public async Task<PaginatedResultDto<DayDto>> Handle(GetListDayQuery request, CancellationToken cancellationToken)
        {
            var query = _DayRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name)),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.DayErrorConstant.DAY_NOT_FOUND);
            var result = _mapper.Map<List<DayDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<DayDto>(result, totalCount);

        }
    }
}
