using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.Abstractions.BaseQuery
{
    public class BasePaginatedQueryResponse<T>
    {
        public long TotalCount { get; set; }
        public T Data { get; set; }
        public BasePaginatedQueryResponse()
        {

        }
    }
}
