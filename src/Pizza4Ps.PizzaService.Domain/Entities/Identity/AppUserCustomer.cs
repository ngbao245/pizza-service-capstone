using Microsoft.AspNetCore.Identity;
using Pizza4Ps.PizzaService.Domain.Abstractions;
using Pizza4Ps.PizzaService.Domain.Abstractions.Entities;

namespace Pizza4Ps.PizzaService.Domain.Entities.Identity
{
    public class AppUserCustomer : EntityAuditBase<Guid>
    {
        public string UserName { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string Salt { get; set; } = string.Empty; // Dùng để tăng độ bảo mật
        public virtual Customer Customer { get; set; }
        private AppUserCustomer() { } // Required for EF Core

        public AppUserCustomer(string userName, string passwordHash, string salt)
        {
            Id = Guid.NewGuid();
            UserName = userName;
            PasswordHash = passwordHash;
            Salt = salt;
        }
    }
}
