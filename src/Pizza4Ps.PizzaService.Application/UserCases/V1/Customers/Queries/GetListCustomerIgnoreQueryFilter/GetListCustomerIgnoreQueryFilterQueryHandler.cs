using AutoMapper;
using Azure.Identity;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using System.Linq.Dynamic.Core;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomerIgnoreQueryFilter
{
    public class GetListCustomerIgnoreQueryFilterQueryHandler : IRequestHandler<GetListCustomerIgnoreQueryFilterQuery, PaginatedResultDto<CustomerDto>>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerIgnoreQueryFilterQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<PaginatedResultDto<CustomerDto>> Handle(GetListCustomerIgnoreQueryFilterQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(includeProperties: request.IncludeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.FullName == null || x.FullName.Contains(request.FullName))
                    && (request.Phone == null || x.Phone.Contains(request.Phone))
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount).ToListAsync();
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new PaginatedResultDto<CustomerDto>(result, totalCount);
        }
    }
}
