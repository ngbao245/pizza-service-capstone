﻿using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ReservationSlots.Queries.GetReservationSlotList
{
    public class GetReservationSlotListQueryHandler : IRequestHandler<GetReservationSlotListQuery, PaginatedResultDto<ReservationSlotDto>>
    {
        private readonly IMapper _mapper;
        private readonly IReservationSlotRepository _reservationSlotRepository;

        public GetReservationSlotListQueryHandler(IMapper mapper, IReservationSlotRepository reservationSlotRepository)
        {
            _mapper = mapper;
            _reservationSlotRepository = reservationSlotRepository;
        }

        public async Task<PaginatedResultDto<ReservationSlotDto>> Handle(GetReservationSlotListQuery request, CancellationToken cancellationToken)
        {
            var query = _reservationSlotRepository.GetListAsNoTracking(
                includeProperties: request.IncludeProperties);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<ReservationSlotDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<ReservationSlotDto>(result, totalCount);
        }
    }
}
