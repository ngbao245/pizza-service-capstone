using MediatR;
using Microsoft.AspNetCore.Http;

namespace Pizza4Ps.PizzaService.Application.UserCases.V1.Products.Commands.UpdateImageProduct
{
    public class UpdateImageProductCommand : IRequest
    {
        public Guid Id { get; set; }
        public IFormFile? file { get; set; }
    }
}
