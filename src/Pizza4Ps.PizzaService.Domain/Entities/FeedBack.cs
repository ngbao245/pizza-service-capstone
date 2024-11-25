using StructureCodeSolution.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Domain.Entities
{
    public class FeedBack : EntityAuditBase<Guid>
    {
        public string Description { get; set; }
        
    }
}
