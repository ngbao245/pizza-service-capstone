using Castle.Core.Resource;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Pizza4Ps.PizzaService.Application.Helpers;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Persistence;
using Pizza4Ps.PizzaService.Persistence.Repositories;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Workshops.Commands.CancelWorkshop
{
    public class CancelWorkshopCommandHandler : IRequestHandler<CancelWorkshopCommand>
    {
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;
        private readonly EmailService _emailService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopRepository _workshopRepository;

        public CancelWorkshopCommandHandler(IUnitOfWork unitOfWork,
            EmailService emailService,
            IWorkshopRepository workshopRepository,
            IWorkshopRegisterRepository workshopRegisterRepository)
        {
            _workshopRegisterRepository = workshopRegisterRepository;
            _emailService = emailService;
            _unitOfWork = unitOfWork;
            _workshopRepository = workshopRepository;
        }
        public async Task Handle(CancelWorkshopCommand request, CancellationToken cancellationToken)
        {
            var workshopRegister = await _workshopRegisterRepository.GetListAsNoTracking(x => x.WorkshopId == request.WorkshopId).ToListAsync();

            var workshop = await _workshopRepository.GetSingleByIdAsync(request.WorkshopId);
            List<(string name, string email)> customerInfos = workshopRegister
                .Select(c => (c.CustomerName, c.CustomerEmail))  // ánh xạ thành tuple
                .ToList();
            if (customerInfos.Any())
            {
                await _emailService.SendCancelWorkshopEmail(customerInfos, workshop.Name, workshop.WorkshopDate);
            }
            workshop.SetCancel();
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
