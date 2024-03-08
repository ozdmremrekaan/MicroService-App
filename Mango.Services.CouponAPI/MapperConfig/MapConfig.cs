using AutoMapper;
using Mango.Services.CouponAPI.Models;
using Mango.Services.CouponAPI.Models.Dto.CouponDto;

namespace Mango.Services.CouponAPI.MapperConfig
{
    public class MapConfig:Profile
    {
        public MapConfig()
        {
            CreateMap<Coupon, CouponDto>().ReverseMap();
        }
    }
}
