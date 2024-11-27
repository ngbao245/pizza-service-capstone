using MediatR;
using Pizza4Ps.PizzaService.Application.Abstractions.BaseCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.UpdateProduct
{
    public class UpdateProductCommand : BaseCommand<Guid>, IRequest
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public Guid CategoryId { get; set; }
    }
}
