using AutoMapper;
using Data.Models;
using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Mapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<CartItem, CartItemDTO>()
                .ForMember(x => x.Discount, opt => opt.MapFrom(x => x.Discount.DiscountPercent))
                .ForMember(x => x.DiscountId, opt => opt.MapFrom(x => x.DiscountId))
                .ForMember(x => x.ItemId, opt => opt.MapFrom(x => x.ItemId))
                .ForMember(x => x.ItemName, opt => opt.MapFrom(x => x.Item.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Item.Price));
        }
    }
}
