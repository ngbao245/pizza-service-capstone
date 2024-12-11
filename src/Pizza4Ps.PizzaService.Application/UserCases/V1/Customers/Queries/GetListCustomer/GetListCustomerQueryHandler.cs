using System.Linq.Dynamic.Core;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetListCustomer
{
    public class GetListCustomerQueryHandler : IRequestHandler<GetListCustomerQuery, GetListCustomerQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetListCustomerQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetListCustomerQueryResponse> Handle(GetListCustomerQuery request, CancellationToken cancellationToken)
        {
            var query = _customerRepository.GetListAsNoTracking(includeProperties: request.includeProperties).IgnoreQueryFilters()
                .Where(
                    x => (request.FullName == null || x.FullName.Contains(request.FullName))
                    && (request.Phone == null || x.Phone.Contains(request.Phone))
                    && x.IsDeleted == request.IsDeleted);
            var entities = await query
                .OrderBy(request.SortBy)
                .Skip(request.SkipCount).Take(request.TakeCount)
                .ToListAsync();
            var result = _mapper.Map<List<CustomerDto>>(entities);
            var totalCount = await query.CountAsync();
            return new GetListCustomerQueryResponse(result, totalCount);
        }
    }
}
