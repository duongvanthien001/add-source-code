namespace HaNeeStore.Models
{
    public class Cart
    {
        public int SubTotal { get; set; } = 0;
        public int Count { get; set; } = 0;
        public virtual List<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
