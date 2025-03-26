using AutoMapper;
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
            StaffTypeEnum? staffType = null;
            if (!string.IsNullOrEmpty(request.StaffType))
            {
                if (!Enum.TryParse(request.StaffType, true, out StaffTypeEnum parsedStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.INVALID_STAFF_TYPE);
                }
                staffType = parsedStatus;
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
                && (staffType == null || x.StaffType == staffType)
                && (staffStatus == null || x.Status == staffStatus),
                includeProperties: includeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            if (!entities.Any())
                throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);
            var result = _mapper.Map<List<StaffDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<StaffDto>(result, totalCount);
        }
    }
}
