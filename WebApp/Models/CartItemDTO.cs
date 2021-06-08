using System.Collections.Generic;

namespace WebApp.Models
{
    public class CartItemDTO
    {
        public CartItemDTO()
        {
            Items = new Dictionary<int, string>();
        }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Amount { get; set; }

        public decimal Price { get; set; }

        public int? DiscountId { get; set; }

        public double? Discount { get; set; }

        public Dictionary<int, string> Items { get; set; }

    }
}
