using AutoMapper;
using Pizza4Ps.PizzaService.Application.DTOs;
using Pizza4Ps.PizzaService.Domain.Entities;
using Pizza4Ps.PizzaService.Domain.Enums;

namespace Pizza4Ps.PizzaService.Application.Mappers
{
    public class VoucherBatchProfile : Profile
    {
        public VoucherBatchProfile()
        {
            CreateMap<VoucherBatchDto, VoucherBatch>().ReverseMap()
                .ForMember(dest => dest.DiscountType, opt => opt.MapFrom(src => Enum.GetName(typeof(DiscountTypeEnum), src.DiscountType)));
        }
    }
}
