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
            List<ZoneTypeEnum>? zoneTypes = null;
            if (request.Type != null)
            {
                zoneTypes = request.Type
                    .Select(type => Enum.TryParse<ZoneTypeEnum>(type, true, out var parsedType) ? parsedType : (ZoneTypeEnum?)null)
                    .Where(type => type.HasValue)
                    .Select(type => type.Value)
                    .ToList();

                if (zoneTypes == null)
                {
                    throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.INVALID_ZONE_TYPE);
                }
            }

            var query = _zoneRepository.GetListAsNoTracking(
                x => (request.Name == null || x.Name.Contains(request.Name))
                && (request.Description == null || x.Description.Contains(request.Description))
                && (zoneTypes == null || zoneTypes.Contains(x.Type)),

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
