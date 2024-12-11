using AutoMapper;
using MediatR;
using Pizza4Ps.PizzaService.Application.DTOs.Customers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, GetCustomerByIdQueryResponse>
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(IMapper mapper, ICustomerRepository customerRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
        }

        public async Task<GetCustomerByIdQueryResponse> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            var entity = await _customerRepository.GetSingleByIdAsync(request.Id);
            var result = _mapper.Map<CustomerDto>(entity);
            return new GetCustomerByIdQueryResponse
            {
                customer = result
            };
        }
    }
}
