using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemByOrderId
{
    public class GetOrderItemByOrderIdQueryHandler : IRequestHandler<GetOrderItemByOrderIdQuery, List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOptionItemOrderItemRepository _optionItemOrderItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemByOrderIdQueryHandler(IOrderItemRepository orderItemRepository, IOptionItemOrderItemRepository optionItemOrderItemRepository, IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _optionItemOrderItemRepository = optionItemOrderItemRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> Handle(GetOrderItemByOrderIdQuery request, CancellationToken cancellationToken)
        {
            var orderItems = await _orderItemRepository.GetListAsTracking(
                    x => x.OrderId == request.Id,
                    includeProperties: "Product,Order")
                .ToListAsync(cancellationToken);

            if (!orderItems.Any()) return new List<OrderItemDto>();

            var orderItemIds = orderItems.Select(x => x.Id).ToList();

            var optionItemOrderItems = await _optionItemOrderItemRepository.GetListAsTracking(
                    x => orderItemIds.Contains(x.OrderItemId),
                    includeProperties: "OptionItem.Option")
                .ToListAsync(cancellationToken);

            var orderItemDtos = _mapper.Map<List<OrderItemDto>>(orderItems);

            foreach (var orderItemDto in orderItemDtos)
            {
                orderItemDto.OptionItemOrderItems = _mapper.Map<List<OptionItemOrderItemDto>>(
                    optionItemOrderItems.Where(x => x.OrderItemId == orderItemDto.Id).ToList()
                );
            }

            return orderItemDtos;
        }
    }
}
