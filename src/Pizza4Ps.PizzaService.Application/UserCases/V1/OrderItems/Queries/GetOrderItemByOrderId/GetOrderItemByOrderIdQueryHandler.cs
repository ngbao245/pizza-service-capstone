using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.OrderItems.Queries.GetOrderItemByOrderId
{
    public class GetOrderItemByOrderIdQueryHandler : IRequestHandler<GetOrderItemByOrderIdQuery, List<OrderItemDto>>
    {
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderItemDetailRepository _optionItemOrderItemRepository;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IMapper _mapper;

        public GetOrderItemByOrderIdQueryHandler(
            IOrderItemRepository orderItemRepository,
            IOrderItemDetailRepository optionItemOrderItemRepository,
            IOptionItemRepository optionItemRepository,
            IMapper mapper)
        {
            _orderItemRepository = orderItemRepository;
            _optionItemOrderItemRepository = optionItemOrderItemRepository;
            _optionItemRepository = optionItemRepository;
            _mapper = mapper;
        }

        public async Task<List<OrderItemDto>> Handle(GetOrderItemByOrderIdQuery request, CancellationToken cancellationToken)
        {
            ////lấy các order item thuộc order
            //var items = await _orderItemRepository.GetListAsTracking(x => x.OrderId == request.Id).ToListAsync();
            //if (items == null) throw new BusinessException(BussinessErrorConstants.OrderItemErrorConstant.ORDER_ITEM_NOT_FOUND);
            //foreach (var item in items)
            //{
            //    var itemOptions = await _optionItemOrderItemRepository.GetListAsTracking(
            //        x => x.OrderItemId == item.Id, includeProperties: "OptionItem").ToListAsync();
            //}

            //var result = _mapper.Map<OrderItemDto>(entities);
            //return result;
        
            throw new NotImplementedException();
        }
    }
}
