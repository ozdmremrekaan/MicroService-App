using AutoMapper;
using Mango.Services.ProductAPI.Models;
using Mango.Services.ProductAPI.Models.Dto;

namespace Mango.Services.ProductAPI.MapperConfig
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
