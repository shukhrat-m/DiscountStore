using AutoMapper;
using Core.Interfaces;
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
                .ForMember(x => x.DiscountId, opt => opt.MapFrom(x => x.DiscountId))
                .ForMember(x => x.ItemId, opt => opt.MapFrom(x => x.ItemId))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.TotalPrice));

            CreateMap<CartItemDTO, CartItem>()
                .ForMember(x => x.ItemId, opt => opt.MapFrom(x => x.ItemId))
                .ForMember(x => x.DiscountId, opt => opt.MapFrom(x => x.DiscountId));

            CreateMap<Item, ItemDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price));

            CreateMap<Discount, DiscountDTO>()
                .ForMember(x => x.Id, opt => opt.MapFrom(x => x.Id))
                .ForMember(x => x.DiscountPercent, opt => opt.MapFrom(x => x.DiscountPercent))
                .ForMember(x => x.Count, opt => opt.MapFrom(x => x.Count))
                .ForMember(x => x.ItemId, opt => opt.MapFrom(x => x.ItemId))
                .ForMember(x => x.ItemName, opt => opt.MapFrom(x => x.ItemName));

            CreateMap<ItemDTO, Item>()
                .ForMember(x => x.Name, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Price, opt => opt.MapFrom(x => x.Price));

            CreateMap<DiscountDTO, Discount>()
                .ForMember(x => x.Count, opt => opt.MapFrom(x => x.Count))
                .ForMember(x => x.DiscountPercent, opt => opt.MapFrom(x => x.DiscountPercent))
                .ForMember(x => x.ItemId, opt => opt.MapFrom(x => x.ItemId));
        }
    }
}
