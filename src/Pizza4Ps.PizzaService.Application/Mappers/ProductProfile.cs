using AutoMapper;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Commands.CreateProduct;
using Pizza4Ps.PizzaService.Application.UserCases.V1.ProductUserCases.Queries.GetProduct;
using Pizza4Ps.PizzaService.Domain.Entities;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<CreateProductCommand, Product>().ReverseMap();
            CreateMap<GetProductQueryResponse, Product>().ReverseMap();
        }
    }
}
