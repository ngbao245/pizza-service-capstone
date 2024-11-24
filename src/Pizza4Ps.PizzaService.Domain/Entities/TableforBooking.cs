using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class TableforBooking : EntityAuditBase<Guid>
    {
        public DateTime OnholdTime { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }

        private TableforBooking() { }

        public TableforBooking(Guid id, DateTime onholdtime)
        {
            Id = id;
            OnholdTime = onholdtime;
        }
    }
}
