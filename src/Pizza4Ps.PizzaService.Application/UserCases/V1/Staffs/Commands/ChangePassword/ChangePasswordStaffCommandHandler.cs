using MediatR;
using Microsoft.AspNetCore.Identity;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Domain.Exceptions;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Staffs.Commands.ChangePassword
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordStaffCommand>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IStaffRepository _staffRepository;

        public ChangePasswordCommandHandler(UserManager<AppUser> userManager, IStaffRepository staffRepository)
        {
            _userManager = userManager;
            _staffRepository = staffRepository;
        }

        public async Task Handle(ChangePasswordStaffCommand request, CancellationToken cancellationToken)
        {
            var staff = await _staffRepository.GetSingleByIdAsync(request.StaffId!.Value);
            if (staff == null)
            {
                throw new BusinessException(BussinessErrorConstants.StaffErrorConstant.STAFF_NOT_FOUND);
            }
            var user = await _userManager.FindByIdAsync(staff.AppUserId.ToString());

            // Đổi mật khẩu
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded)
            {
                var errorMessage = string.Join(", ", result.Errors.Select(e => e.Description));
                if (result.Errors.Any(e => e.Code == "PasswordMismatch"))
                {
                    throw new BusinessException("Mật khẩu hiện tại không chính xác");
                }

                throw new BusinessException(errorMessage);
            }
        }
    }
}
