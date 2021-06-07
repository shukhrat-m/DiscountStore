namespace Data.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        public int ItemId { get; set; }
        
        public Item Item { get; set; }
        
        public int DiscountId { get; set; }
        
        public Discount Discount { get; set; }
    }
}
