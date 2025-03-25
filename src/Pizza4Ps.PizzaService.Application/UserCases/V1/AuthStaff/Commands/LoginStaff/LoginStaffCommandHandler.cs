using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Domain.Constants;
using Pizza4Ps.PizzaService.Domain.Entities.Identity;
using Pizza4Ps.PizzaService.Domain.Exceptions;
using Pizza4Ps.PizzaService.Domain.Helpers;
using Pizza4Ps.PizzaService.Persistence.Repositories;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.AuthStaff.Commands.LoginStaff
{
    public class LoginStaffCommandHandler : IRequestHandler<LoginStaffCommand, LoginStaffCommandResponse>
    {
        private readonly IConfiguration _configuration;
        private readonly IStaffRepository _staffRepository;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<AppRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public LoginStaffCommandHandler(UserManager<AppUser> userManager,
                            SignInManager<AppUser> signInManager,
                            RoleManager<AppRole> roleManager,
                            IConfiguration configuration, IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _userManager = userManager;
        }
        public async Task<LoginStaffCommandResponse> Handle(LoginStaffCommand request, CancellationToken cancellationToken)
        {
            // Tìm user theo UserName
            var user = await _userManager.FindByNameAsync(request.Username);
            if (user == null)
                throw new BusinessException("Invalid username, please try again");

            // Kiểm tra mật khẩu
            var result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!result.Succeeded)
                throw new BusinessException("Invalid password, please try again");

            var staff = await _staffRepository.GetSingleAsync(x => x.AppUserId == user.Id);

            if (staff == null)
                throw new BusinessException("Invalid staff information, please contact to host");
            // Tạo danh sách các claim
            var claims = new List<Claim>
            {
                new Claim("AppUserId", user.Id.ToString()),
                new Claim("StaffId", staff.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
                new Claim(JwtRegisteredClaimNames.Name, staff.FullName),
                new Claim(ClaimTypes.Role, staff.StaffType.ToString())
            };

            // Cấu hình JWT
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["SecretKey"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expiration = DateTime.UtcNow.AddHours(2);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expiration,
                SigningCredentials = creds
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return new LoginStaffCommandResponse
            {
                Token = tokenString,
                Expiration = expiration
            };
        }
    }
}
