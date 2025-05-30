﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Queries.GetListStaff
{
    public class GetListStaffQueryHandler : IRequestHandler<GetListStaffQuery, PaginatedResultDto<StaffDto>>
    {
        private readonly IMapper _mapper;
        private readonly IStaffRepository _staffRepository;

        public GetListStaffQueryHandler(IMapper mapper, IStaffRepository staffRepository)
        {
            _mapper = mapper;
            _staffRepository = staffRepository;
        }

        public async Task<PaginatedResultDto<StaffDto>> Handle(GetListStaffQuery request, CancellationToken cancellationToken)
        {
            List<StaffTypeEnum>? staffTypes = null;
            if (request.StaffType != null && request.StaffType.Any())
            {
                staffTypes = request.StaffType
                    .Select(type => Enum.TryParse<StaffTypeEnum>(type, true, out var parsedType) ? parsedType : (StaffTypeEnum?)null)
                    .Where(type => type.HasValue)
                    .Select(type => type.Value)
                    .ToList();

                if (staffTypes.Count == 0)
                {
                    throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.INVALID_STAFF_TYPE);
                }
            }

            StaffStatusEnum? staffStatus = null;
            if (!string.IsNullOrEmpty(request.Status))
            {
                if (!Enum.TryParse(request.Status, true, out StaffStatusEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.INVALID_STAFF_STATUS);
                }
                staffStatus = parsedStatus;
            }

            var includeProperties = string.IsNullOrEmpty(request.IncludeProperties) ? "AppUser" : $"{request.IncludeProperties},AppUser";

            var query = _staffRepository.GetListAsNoTracking(
                x => (request.FullName == null || x.FullName.Contains(request.FullName))
                && (request.Phone == null || x.Phone.Contains(request.Phone))
                && (request.Email == null || x.Email.Contains(request.Email))
                && (staffTypes == null || staffTypes.Contains(x.StaffType))
                && (staffStatus == null || x.Status == staffStatus),
                includeProperties: includeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<StaffDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffDto>(result, totalCount);
        }
    }
}
