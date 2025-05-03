using MediatR;
using Microsoft.AspNetCore.Http;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Application.Helpers;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Services;
using Pizza4Ps.PizzaService.Persistence.Helpers;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CreateWorkshopRegister
{
    public class CreateWorkshopRegisterCommandHandler : IRequestHandler<CreateWorkshopRegisterCommand, ResultDto<Guid>>
    {
        private readonly EmailService _emailService;
        private readonly ICustomerRepository _customerRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IWorkshopRegisterService _workshopRegisterService;
        private readonly IOptionItemRepository _optionItemRepository;
        private readonly IProductRepository _productRepository;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IWorkshopRepository _workshopRepository;

        public CreateWorkshopRegisterCommandHandler(
            IWorkshopRepository workshopRepository, IZoneRepository zoneRepository,
            IWorkshopRegisterRepository workshopRegisterRepository,
            IProductRepository productRepository, IOptionItemRepository optionItemRepository,
            IWorkshopRegisterService workshopRegisterService, IHttpContextAccessor httpContextAccessor,
            ICustomerRepository customerRepository, EmailService emailService)
        {
            _emailService = emailService;
            _customerRepository = customerRepository;
            _httpContextAccessor = httpContextAccessor;
            _workshopRegisterService = workshopRegisterService;
            _optionItemRepository = optionItemRepository;
            _productRepository = productRepository;
            _workshopRegisterRepository = workshopRegisterRepository;
            _zoneRepository = zoneRepository;
            _workshopRepository = workshopRepository;
        }
        public async Task<ResultDto<Guid>> Handle(CreateWorkshopRegisterCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetSingleAsync(x => x.Phone == request.PhoneNumber);
            if (customer == null)
            {
                throw new BusinessException("Customer is not found");
            }
            if (customer.PhoneOtp != request.PhoneOtp)
            {
                throw new BusinessException("Phone OTP is not valid");
            }
            var workshop = await _workshopRepository.GetSingleByIdAsync(request.WorkshopId, "WorkshopRegisters");
            if (workshop == null)
            {
                throw new BusinessException("Workshop is not found");
            }
            if (request.Products.Count() > workshop.MaxPizzaPerRegister)
            {
                throw new BusinessException($"You cannot register over {workshop.MaxPizzaPerRegister} products");
            }
            if (request.TotalParticipant > workshop.MaxParticipantPerRegister)
            {
                throw new BusinessException($"You cannot register over {workshop.MaxPizzaPerRegister} participants");
            }
            if (workshop.WorkshopRegisters.Any(x => x.CustomerPhone == request.PhoneNumber && x.WorkshopRegisterStatus != Domain.Enums.WorkshopRegisterStatus.Cancelled))
            {
                throw new BusinessException("You have already registered for this workshop");
            }
            if (workshop.WorkshopRegisters.Count(x => x.WorkshopRegisterStatus != Domain.Enums.WorkshopRegisterStatus.Cancelled) >= workshop.MaxRegister)
            {
                throw new BusinessException("This workshop is full");
            }
            var workshopCode = RegistrationCodeGenerator.GenerateCode();
            var workshopRegister = new WorkshopRegister(
                customerName: request.CustomerName,
                customerPhone: request.PhoneNumber,
                customerEmail: request.Email,
                workshopId: request.WorkshopId,
                registeredAt: DateTime.Now,
                totalFee: workshop.TotalFee,
                code: workshopCode,
                totalParticipant: request.TotalParticipant);
            var workshopPizzaRegisters = new List<WorkshopPizzaRegister>();
            var workshopPizzaRegisterDetails = new List<WorkshopPizzaRegisterDetail>();
            foreach (var product in request.Products)
            {
                var productEntity = await _productRepository.GetSingleByIdAsync(product.ProductId);
                if (productEntity == null)
                    throw new BusinessException("Product is not found");
                var workshopPizzaRegister = new WorkshopPizzaRegister(
                    workshopRegisterId: workshopRegister.Id,
                    productId: product.ProductId,
                    price: productEntity.Price,
                    name: productEntity.Name,
                    totalPrice: productEntity.Price);
                decimal? totalPrice = productEntity.Price;
                foreach (var optionItemId in product.OptionItemIds)
                {
                    var optionItem = await _optionItemRepository.GetSingleByIdAsync(optionItemId);
                    if (optionItem == null)
                        throw new BusinessException("Option item is not found");
                    var workshopPizzaRegisterDetail = new WorkshopPizzaRegisterDetail(
                        workshopPizzaRegisterId: workshopPizzaRegister.Id,
                        additionalPrice: optionItem.AdditionalPrice,
                        optionItemId: optionItemId,
                        name: optionItem.Name
                        );
                    totalPrice += optionItem.AdditionalPrice;
                    workshopPizzaRegisterDetails.Add(workshopPizzaRegisterDetail);
                }
                workshopPizzaRegister.TotalPrice = totalPrice.Value;
                workshopPizzaRegisters.Add(workshopPizzaRegister);
            }
            await _workshopRegisterService.RegisterAsync(workshopRegister, workshopPizzaRegisters, workshopPizzaRegisterDetails);

            await _emailService.SendWorkshopRegisterEmail(request.Email, customer.FullName ?? "Quý khách", workshop.Name, workshopRegister.Code);

            return new ResultDto<Guid>()
            {
                Id = workshopRegister.Id,
            };
        }



    }
}
