namespace Business.Models
{
    public class CartModel
    {
        public int BookId { get; set; }
        public int UserId { get; set; }
        public string BookName { get; set; }
        public double UnitPrice { get; set; }
    }
}
