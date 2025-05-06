using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CreateWorkshop
{
    public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand, ResultDto<Guid>>
    {
        private readonly IWorkshopRepository _workshopRepository;
        private readonly IProductRepository _productRepository;
        private readonly IZoneRepository _zoneRepository;
        private readonly IWorkshopService _workshopService;

        public CreateWorkshopCommandHandler(
            IWorkshopService workshopService, IZoneRepository zoneRepository,
            IProductRepository productRepository,
            IWorkshopRepository workshopRepository)
        {
            _workshopRepository = workshopRepository;
            _productRepository = productRepository;
            _zoneRepository = zoneRepository;
            _workshopService = workshopService;
        }
        public async Task<ResultDto<Guid>> Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
        {
            if (request.StartRegisterDate <= DateTime.Now || request.EndRegisterDate <= DateTime.Now
                || request.WorkshopDate <= DateTime.Now)
            {
                throw new BusinessException("Không được thiệt lập thời gian ngắn hơn thời gian hiện tại");
            }
            if (request.StartRegisterDate > request.EndRegisterDate)
            {
                throw new BusinessException("Thời gian bắt đầu đăng ký không được nhỏ hơn thời gian dừng đăng ký");
            }
            if (request.WorkshopDate <= request.EndRegisterDate)
            {
                throw new BusinessException("Thời gian bắt đầu workshop không được nhỏ hơn thời gian dừng đăng ký");
            }
            var zone = await _zoneRepository.GetSingleByIdAsync(request.ZoneId, "Tables");
            if (zone == null)
            {
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);
            }
            var products = _productRepository.GetListAsTracking(x => request.ProductIds.Contains(x.Id));
            var workshop = new Workshop(
                name: request.Name, header: request.Header,
                description: request.Description,
                location: request.Location,
                organizer: request.Organizer,
                hotLineContact: request.HotLineContact,
                workshopDate: request.WorkshopDate,
                startRegisterDate: request.StartRegisterDate,
                endRegisterDate: request.EndRegisterDate,
                totalFee: request.TotalFee,
                maxRegister: request.MaxRegister,
                maxParticipantPerRegister: request.MaxParticipantPerRegister,
                maxPizzaPerRegister: request.MaxPizzaPerRegister,
                zoneId: request.ZoneId, zoneName: zone.Name
                );
            var workshopFoodDetails = new List<WorkshopFoodDetail>();
            foreach (var item in request.ProductIds)
            {
                var product = products.FirstOrDefault(x => x.Id == item);
                if (product == null)
                {
                    throw new BusinessException(BussinessErrorConstants.ProductErrorConstant.PRODUCT_NOT_FOUND);
                }
                var workshopFoodDetail = new WorkshopFoodDetail(workshopId: workshop.Id, productId: item, name: product.Name, price: product.Price);
                workshopFoodDetails.Add(workshopFoodDetail);
            }

            await _workshopService.CreateAsync(workshop, workshopFoodDetails);
            return new ResultDto<Guid>()
            {
                Id = workshop.Id,
            };
        }
    }
}
