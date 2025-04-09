using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;
using System.Security.Claims;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.AssignTableWorkshopRegister
{
    public class AssignTableWorkshopRegisterCommandHandler : IRequestHandler<AssignTableWorkshopRegisterCommand>
    {
        private readonly IAdditionalFeeRepository _additionalFeeRepository;
        private readonly IOrderItemDetailRepository _orderItemDetailRepository;
        private readonly IOrderItemRepository _orderItemRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ITableRepository _tableRepository;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;

        public AssignTableWorkshopRegisterCommandHandler(IUnitOfWork unitOfWork,
            IWorkshopRegisterRepository workshopRegisterRepository, ITableRepository tableRepository,
            IOrderRepository orderRepository,
            IOrderItemRepository orderItemRepository,
            IOrderItemDetailRepository orderItemDetailRepository,
            IAdditionalFeeRepository additionalFeeRepository)
        {
            _additionalFeeRepository = additionalFeeRepository;
            _orderItemDetailRepository = orderItemDetailRepository;
            _orderItemRepository = orderItemRepository;
            _orderRepository = orderRepository;
            _unitOfWork = unitOfWork;
            _tableRepository = tableRepository;
            _workshopRegisterRepository = workshopRegisterRepository;
        }
        public async Task Handle(AssignTableWorkshopRegisterCommand request, CancellationToken cancellationToken)
        {
            var workshopRegister = await _workshopRegisterRepository.GetSingleByIdAsync(request.WorkshopRegisterId,
                "WorkshopPizzaRegisters.WorkshopPizzaRegisterDetails");
            if (workshopRegister == null)
            {
                throw new BusinessException("Workshop registery is not found");
            }
            var table = await _tableRepository.GetSingleByIdAsync(request.TableId);
            if (table == null)
            {
                throw new BusinessException("Table is not found");
            }
            if (table.Status != Domain.Enums.TableStatusEnum.Closing)
            {
                throw new BusinessException("Table is invalid to assign");
            }
            if (table.CurrentOrderId != null)
            {
                throw new BusinessException("Table is taken");
            }
            var orderItems = new List<OrderItem>();
            var order = new Order(
                id: Guid.NewGuid(),
                tableId: table.Id,
                tableCode: table.Code,
                type: Domain.Enums.OrderTypeEnum.Workshop
                );
            foreach (var workshopPizzaRegister in workshopRegister.WorkshopPizzaRegisters)
            {

                var orderItem = new OrderItem(
                    id: Guid.NewGuid(),
                    name: workshopPizzaRegister.Name,
                    quantity: 1,
                    price: workshopPizzaRegister.Price,
                    orderId: order.Id,
                    productId: workshopPizzaRegister.ProductId,
                    tableCode: table.Code,
                    note: null,
                    DateTime.Now,
                    type: Domain.Enums.OrderTypeEnum.Workshop,
                    productType: null);
                orderItems.Add(orderItem);
                foreach (var workshopPizzaRegisterDetail in workshopPizzaRegister.WorkshopPizzaRegisterDetails)
                {
                    var orderItemDetail = new OrderItemDetail(
                        id: Guid.NewGuid(),
                        name: workshopPizzaRegisterDetail.Name,
                        additionalPrice: workshopPizzaRegisterDetail.AdditionalPrice,
                        orderItemId: orderItem.Id
                    );
                    //_optionItemOrderItemRepository.Add(orderDetail);
                    orderItem.OrderItemDetails.Add(orderItemDetail);
                }
                orderItem.SetTotalPrice();
            }
            workshopRegister.AssignTableOrder(table.Id, order.Id);
            table.SetOpening();
            table.SetCurrentOrderId(order.Id);
            _orderRepository.Add(order);
            _orderItemRepository.AddRange(orderItems);
            _tableRepository.Update(table);
            _workshopRegisterRepository.Update(workshopRegister);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
