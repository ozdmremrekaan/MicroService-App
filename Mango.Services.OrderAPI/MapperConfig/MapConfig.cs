using AutoMapper;
using Mango.Services.OrderAPI.Models;
using Mango.Services.OrderAPI.Models.Dto;

namespace Mango.Services.OrderAPI.MapperConfig
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<OrderHeaderDto, CartHeaderDto>()
                .ForMember(d => d.CartTotal,u=>u.MapFrom(src => src.OrderTotal)).ReverseMap();
            CreateMap<CartDetailsDto, OrderDetailsDto>()
                .ForMember(d => d.ProductName, u => u.MapFrom(src => src.Product.Name))
                .ForMember(d => d.Price, u => u.MapFrom(src => src.Product.Price));
            CreateMap<OrderDetailsDto, CartDetailsDto>();

            CreateMap<OrderHeader, OrderHeaderDto>().ReverseMap();
            CreateMap<OrderDetailsDto, OrderDetails>().ReverseMap();
        }
    }
}
