﻿namespace Pizza4Ps.PizzaService.Application.DTOs
{
    public class StaffZoneDto
    {
        public Guid Id { get; set; }
        public string? Note { get; set; }
        public Guid StaffId { get; set; }
        public Guid ZoneId { get; set; }

        public virtual StaffDto Staff { get; set; }
        public virtual ZoneDto Zone { get; set; }
    }
}
