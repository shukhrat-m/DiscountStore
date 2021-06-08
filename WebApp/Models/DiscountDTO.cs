using System.Collections.Generic;

namespace WebApp.Models
{
    public class DiscountDTO
    {
        public DiscountDTO()
        {
            Items = new Dictionary<int, string>();
        }

        public int Id { get; set; }

        public int Count { get; set; }

        public double DiscountPercent { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public Dictionary<int, string> Items { get; set; }

    }
}
