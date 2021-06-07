namespace WebApp.Models
{
    public class CartItemDTO
    {
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal Price { get; set; }

        public int DiscountId { get; set; }

        public double Discount { get; set; }

    }
}
