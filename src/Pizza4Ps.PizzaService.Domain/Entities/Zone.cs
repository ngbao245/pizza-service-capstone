using Pizza4Ps.PizzaService.Domain.Enums;
using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class Zone : EntityAuditBase<Guid>
    {
        public string ZoneName { get; set; }
        public int ZoneCapacity { get; set; }
        public ZoneTypeEnum ZoneTypeEnum { get; set; }
        public virtual ICollection<Table> Tables { get; set; }
        public virtual ICollection<StaffSchedule> StaffSchedules {  get; set; }
        public virtual ICollection<StaffScheduleLog> StaffScheduleLogs {get; set; }
        
        private Zone() { }

        public Zone(Guid id ,string zoneName, int zoneCapacity, ZoneTypeEnum zoneTypeEnum)
        {
            Id = id;
            ZoneName = zoneName;
            ZoneCapacity = zoneCapacity;
            ZoneTypeEnum = zoneTypeEnum;
        }
    }
}
