using System.Collections.Generic;

namespace WebApp.Models
{
    public class CartItemsDTO
    {
        public CartItemsDTO()
        {
            CartItems = new List<CartItemDTO>();
        }

        public ICollection<CartItemDTO> CartItems { get; set; }

        public decimal TotalPrice { get; set; }

        public string ErrorMessage { get; set; }
    }
}
