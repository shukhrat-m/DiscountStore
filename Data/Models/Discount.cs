using System.Collections.Generic;

namespace Data.Models
{
    public class Discount
    {
        public Discount()
        {
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }

        public int Count { get; set; }
        
        public double DiscountPercent { get; set; }

        public int ItemId { get; set; }
        
        public Item Item { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
    }
}
