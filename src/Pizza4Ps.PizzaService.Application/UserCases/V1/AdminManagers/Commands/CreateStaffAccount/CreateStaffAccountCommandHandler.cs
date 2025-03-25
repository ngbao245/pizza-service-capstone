using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Domain.Enums;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Persistence;
using Pizza4Ps.PizzaService.Persistence.Repositories;
using System.Transactions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AdminManagers.Commands.CreateStaffAccount
{
    public class CreateStaffAccountCommandHandler : IRequestHandler<CreateStaffAccountCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStaffRepository _staffRepository;
        private readonly UserManager<AppUser> _userManager;
        public CreateStaffAccountCommandHandler(UserManager<AppUser> userManager,
            IStaffRepository staffRepository,
            IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _staffRepository = staffRepository;
            _userManager = userManager;
        }
        public async Task Handle(CreateStaffAccountCommand request, CancellationToken cancellationToken)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                if (!Enum.TryParse(request.StaffType, true, out StaffTypeEnum staffType))
                {
                    throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.INVALID_STAFF_TYPE);
                }

                if (!Enum.TryParse(request.Status, true, out StaffStatusEnum staffStatus))
                {
                    throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.INVALID_STAFF_STATUS);
                }

                var user = new AppUser { UserName = request.Username, Email = request.Email };
                var result = await _userManager.CreateAsync(user, request.Password);
                if (!result.Succeeded)
                {
                    throw new BusinessException(string.Join(", ", result.Errors.Select(e => e.Description)));
                }

                var staff = new Staff
                {
                    FullName = request.FullName,
                    Email = request.Email,
                    StaffType = staffType,
                    AppUserId = user.Id,
                    Phone = request.Phone,
                    Status = staffStatus
                };

                _staffRepository.Add(staff);
                await _unitOfWork.SaveChangeAsync();

                // Nếu tới đây không có lỗi, hoàn thành transaction
                scope.Complete();
            }
        }
    }
}
