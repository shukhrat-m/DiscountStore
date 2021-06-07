using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Item
    {
        public Item()
        {
            Discounts = new HashSet<Discount>();
            CartItems = new HashSet<CartItem>();
        }

        public int Id { get; set; }

        public int Name { get; set; }

        public decimal Price { get; set; }

        public virtual ICollection<Discount> Discounts { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }

    }
}
