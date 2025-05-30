﻿//using AutoMapper;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using Pizza4Ps.PizzaService.Application.Abstractions;
//using Pizza4Ps.PizzaService.Application.DTOs;
//using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
//using System.Linq.Dynamic.Core;

//namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Bookings.Queries.GetListBookingIgnoreQueryFilter
//{
//    public class GetListBookingIgnoreQueryFilterQueryHandler : IRequestHandler<GetListBookingIgnoreQueryFilterQuery, PaginatedResultDto<BookingDto>>
//    {
//        private readonly IMapper _mapper;
//        private readonly IBookingRepository _BookingRepository;

//        public GetListBookingIgnoreQueryFilterQueryHandler(IMapper mapper, IBookingRepository BookingRepository)
//        {
//            _mapper = mapper;
//            _BookingRepository = BookingRepository;
//        }

//        public async Task<PaginatedResultDto<BookingDto>> Handle(GetListBookingIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
//        {
//            var query = _BookingRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
//                .Where(
//                    x => (request.BookingDate == null || x.BookingDate == request.BookingDate)
//                    && (request.GuestCount == null || x.GuestCount == request.GuestCount)
//                    && (request.Status == null || x.Status == request.Status)
//                    && (request.CustomerId == null || x.CustomerId == request.CustomerId)
//                    && x.IsDeleted == request.IsDeleted);
//            var entities = await query
//                .OrderBy(request.SortBy)
//                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
//            var result = _mapper.Map<List<BookingDto>>(entities);
//            var totalCount = await query.CountAsync();
//            return new PaginatedResultDto<BookingDto>(result, totalCount);
//        }
//    }
//}
