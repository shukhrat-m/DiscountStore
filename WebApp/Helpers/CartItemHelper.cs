using Core.Interfaces;
using Data.Models;
using WebApp.Models;

namespace WebApp.Helpers
{
    public static class CartItemHelper
    {
        public static decimal GetTotalPrice(CartItemDTO inModel, Item item, Discount discount)
        {
            if (discount != null)
            {
                var itemWithoutDiscount = inModel.Amount % discount.Count;
                var discountPrice = (inModel.Amount - itemWithoutDiscount) * item.Price * ((decimal)discount.DiscountPercent / 100);
                return (inModel.Amount * item.Price) - discountPrice;
            }

            return item.Price * inModel.Amount;
        }

        public static CartItemsDTO IncludeItemNameAndDiscount(CartItemsDTO cartItemsDTO, IItemService itemService, IDiscountService discountService)
        {
            foreach(CartItemDTO cartItemDTO in cartItemsDTO.CartItems)
            {
                if (cartItemDTO.DiscountId.HasValue)
                {
                    cartItemDTO.Discount = discountService.GetById(cartItemDTO.DiscountId.Value).DiscountPercent;
                }
                cartItemDTO.ItemName = itemService.GetById(cartItemDTO.ItemId).Name;
            }

            return cartItemsDTO;
        }
    }
}
