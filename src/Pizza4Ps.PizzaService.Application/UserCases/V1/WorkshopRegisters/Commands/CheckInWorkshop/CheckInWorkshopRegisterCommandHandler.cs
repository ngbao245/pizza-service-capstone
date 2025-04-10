using MediatR;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.WorkshopRegisters.Commands.CheckInWorkshop
{
    public class CheckInWorkshopRegisterCommandHandler : IRequestHandler<CheckInWorkshopRegisterCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWorkshopRegisterRepository _workshopRegisterRepository;

        public CheckInWorkshopRegisterCommandHandler(IUnitOfWork unitOfWork,
            IWorkshopRegisterRepository workshopRegisterRepository)
        {
            _unitOfWork = unitOfWork;
            _workshopRegisterRepository = workshopRegisterRepository;
        }
        public async Task Handle(CheckInWorkshopRegisterCommand request, CancellationToken cancellationToken)
        {
            var workshopRegister = await _workshopRegisterRepository.GetSingleByIdAsync(request.WorkshopRegisterId, "Workshop");
            if (workshopRegister == null)
            {
                throw new BusinessException("Workshop registery is not found");
            }
            if (workshopRegister.Workshop.WorkshopStatus != Domain.Enums.WorkshopStatus.Opening)
            {
                throw new BusinessException("Workshop hiện chưa mở, vui lòng liên hệ quản lý");
            }
            if (workshopRegister.WorkshopRegisterStatus == Domain.Enums.WorkshopRegisterStatus.Attended)
            {
                throw new BusinessException("Đăng ký này đã được check in, vui lòng kiểm tra lại");
            }
            if (workshopRegister.WorkshopRegisterStatus == Domain.Enums.WorkshopRegisterStatus.Cancel)
            {
                throw new BusinessException("Đăng ký này đã được huỷ, vui lòng kiểm tra lại");
            }
            workshopRegister.CheckIn();
            _workshopRegisterRepository.Update(workshopRegister);
            await _unitOfWork.SaveChangeAsync();
        }
    }
}
