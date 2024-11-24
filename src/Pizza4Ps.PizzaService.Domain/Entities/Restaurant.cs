using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Restaurant : EntityAuditBase<Guid>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal PhoneNumber { get; set; }
        public string Location { get; set; }
        public RestaurantTypeEnum RestaurantType { get; set;}
        public virtual ICollection<Booking> Bookings { get; set; }

        private Restaurant() { }

        public Restaurant(string name, string description, decimal phoneNumber, string location, RestaurantTypeEnum restaurantType)
        {
            Name = name;
            Description = description;
            PhoneNumber = phoneNumber;
            Location = location;
            RestaurantType = restaurantType;
        }
    }
}
