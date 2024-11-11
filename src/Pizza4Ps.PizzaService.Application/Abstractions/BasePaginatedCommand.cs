using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.Abstractions
{
    public class BasePaginatedCommand
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string SortBy { get; set; }
        public string SortOrder { get; set; }
    }
}
