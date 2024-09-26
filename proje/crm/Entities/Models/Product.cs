namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public decimal  price { get; set; }
        public String? Description { get; set; } = String.Empty;
    }
}