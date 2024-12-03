namespace Entities.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public String? ProductName { get; set; } = String.Empty;
        public String?  price { get; set; }
        public String? Description { get; set; } = String.Empty;
        public String? DenemeSüresi { get; set; } = String.Empty;
        public String? descrp { get; set; } = String.Empty;
        public String? PaketSüresi { get; set; } = String.Empty;
    }
}