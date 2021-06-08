using System.Collections.Generic;

namespace WebApp.Models
{
    public class DiscountsDTO
    {
        public DiscountsDTO()
        {
            Discounts = new List<DiscountDTO>();
        }

        public ICollection<DiscountDTO> Discounts { get; set; }

        public string ErrorMessage { get; set; }
    }
}
