using MediatR;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.CreateProduct;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.CategoryUserCases.Commands.CreateCategory
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        public Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            throw new Exception();       
        }
    }
}
