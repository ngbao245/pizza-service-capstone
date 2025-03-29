using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Zones.Queries.GetListZone
{
    public class GetListZoneQueryHandler : IRequestHandler<GetListZoneQuery, PaginatedResultDto<ZoneDto>>
    {
        private readonly IMapper _mapper;
        private readonly IZoneRepository _zoneRepository;

        public GetListZoneQueryHandler(IMapper mapper, IZoneRepository zoneRepository)
        {
            _mapper = mapper;
            _zoneRepository = zoneRepository;
        }

        public async Task<PaginatedResultDto<ZoneDto>> Handle(GetListZoneQuery request, CancellationToken cancellationToken)
        {
            ZoneTypeEnum? zoneType = null;
            if (!string.IsNullOrEmpty(request.Type))
            {
                if (!Enum.TryParse(request.Type, true, out ZoneTypeEnum parsedType))
                {
                    throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.INVALID_ZONE_TYPE);
                }
                zoneType = parsedType;
            }

            var query = _zoneRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (zoneType == null || x.Type == zoneType),
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);
            var result = _mapper.Map<List<ZoneDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ZoneDto>(result, totalCount);
        }
    }
}
