namespace Entities.Models
{
    public class Order
    {
        public int OrderID { get; set; }
        public String? userID { get; set; }
        public int productID { get; set; } 
        public DateTime OrderDate { get; set; } =  DateTime.Now;
        
        
    }
}