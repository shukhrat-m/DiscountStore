using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class Discount
    {
        public int Id { get; set; }

        public int Count { get; set; }
        
        public double DiscountPercent { get; set; }

        public int ItemId { get; set; }
        
        public Item Item { get; set; }
    }
}
