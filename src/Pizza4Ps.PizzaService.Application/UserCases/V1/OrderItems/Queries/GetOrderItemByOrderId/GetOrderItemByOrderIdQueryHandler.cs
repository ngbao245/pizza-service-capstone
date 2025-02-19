using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemByOrderId
{
    public class GetOrderItemByOrderIdQueryHandler : IRequestHandler<GetOrderItemByOrderIdQuery, List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemByOrderIdQueryHandler(
            IOrderItemRepository orderItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> Handle(GetOrderItemByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var entities = await _orderItemRepository.GetListAsTracking(x => x.OrderId == request.Id,
                    includeProperties: "Product,Order")
                .ToListAsync();
            var result = _mapper.Map<List<OrderItemDto>>(entities);
            return result;
        }
    }
}
