using Microsoft.AspNetCore.Http.Features.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery
{
    public class BasePaginatedQuery
    {
        public int TakeCount { get; set; } = 20;
        public int SkipCount { get; set; } = 0;
        public string SortBy { get; set; } = "";
        public string SortOrder { get; set; }
    }
}
