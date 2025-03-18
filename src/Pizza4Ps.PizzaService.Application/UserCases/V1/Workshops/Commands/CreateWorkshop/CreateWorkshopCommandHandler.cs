using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Abstractions.Services;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CreateWorkshop
{
    public class CreateWorkshopCommandHandler : IRequestHandler<CreateWorkshopCommand, ResultDto<Guid>>
    {
        private readonly IZoneRepository _zoneRepository;
        private readonly IWorkshopService _workshopService;

        public CreateWorkshopCommandHandler(
            IWorkshopService workshopService, IZoneRepository zoneRepository)
        {
            _zoneRepository = zoneRepository;
            _workshopService = workshopService;
        }
        public async Task<ResultDto<Guid>> Handle(CreateWorkshopCommand request, CancellationToken cancellationToken)
        {
            var zone = await _zoneRepository.GetSingleByIdAsync(request.ZoneId, "Tables");
            if (zone == null)
            {
                throw new BusinessException(BussinessErrorConstants.ZoneErrorConstant.ZONE_NOT_FOUND);
            }
            var workshop = new Workshop(
                name: request.Name, header: request.Header,
                description: request.Description,
                location: request.Location,
                organizer: request.Location,
                hotLineContact: request.HotLineContact,
                workshopDate: request.WorkshopDate,
                startRegisterDate: request.WorkshopDate,
                endRegisterDate: request.EndRegisterDate,
                totalFee: request.TotalFee,
                maxRegister: zone.Tables.Count(),
                maxParticipantPerRegister: request.MaxPizzaPerRegister,
                maxPizzaPerRegister: request.MaxPizzaPerRegister,
                zoneId: request.ZoneId, zoneName: zone.Name
                );
            var workshopFoodDetails = new List<WorkshopFoodDetail>();
            foreach(var item in request.ProductIds)
            {
                var workshopFoodDetail = new WorkshopFoodDetail(workshopId: workshop.Id, productId: item);
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
