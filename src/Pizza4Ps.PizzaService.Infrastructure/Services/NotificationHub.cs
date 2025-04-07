using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Pizza4Ps.PizzaService.Domain.Abstractions.Repositories;
using Pizza4Ps.PizzaService.Persistence.Helpers;

namespace Pizza4Ps.PizzaService.Infrastructure.Services
{
    public class NotificationHub : Hub
    {
        private readonly IStaffZoneRepository _staffZoneRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ILogger<NotificationHub> _logger;
        private readonly IStaffRepository _staffRepository;

        public NotificationHub(ILogger<NotificationHub> logger,
            IHttpContextAccessor httpContextAccessor,
            IStaffRepository staffRepository,
            IStaffZoneRepository staffZoneRepository)
        {
            _staffZoneRepository = staffZoneRepository;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
            _staffRepository = staffRepository;
        }

        public override async Task OnConnectedAsync()
        {
            // Vì xác thực JWT đã được xử lý bởi middleware, 
            // Context.User chứa các claim từ token.
            var userId = HttpContextHelper.GetStaffId(_httpContextAccessor.HttpContext);

            if (userId == null)
                return;

            var staff = await _staffRepository.GetSingleByIdAsync(userId.Value);

            var zones = await _staffZoneRepository.GetListAsTracking(x => x.StaffId == userId)
                .Include(x => x.Zone).Select(x => x.Zone.Name).ToListAsync();

            // Giả sử thông tin zone được lưu trong claim "zone"


            if (staff.StaffType == Domain.Enums.StaffTypeEnum.Staff && zones.Any())
            {
                foreach(var zone in zones)
                {
                    // Nhân viên sẽ được join vào group theo zone (ví dụ: "Zone_A" nếu zone là A)
                    await Groups.AddToGroupAsync(Context.ConnectionId, $"Zone_{zone}");
                    Console.WriteLine($"Connection {Context.ConnectionId} added to group Zone_{zone}");
                }
            }
            else if (staff.StaffType == Domain.Enums.StaffTypeEnum.Manager)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "ManagersGroup");
                Console.WriteLine($"Connection {Context.ConnectionId} added to group ManagersGroup");
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "DefaultGroup");
                Console.WriteLine($"Connection {Context.ConnectionId} added to group DefaultGroup");
            }
            await base.OnConnectedAsync();
        }
    }
}
