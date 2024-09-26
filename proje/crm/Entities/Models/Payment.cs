namespace Entities.Models
{
    public class Payment
    {
        public int Id { get; set; } // Ödeme ID'si

        public String? UserID { get; set; }

        public int productId { get; set; }
        public decimal Amount { get; set; } // Ödeme miktarı
        public String? CardHolderName { get; set; } // Kart üzerindeki isim
        public String? CardNumber { get; set; } // Kart numarası
        public String? ExpirationMonth { get; set; } // Son kullanma tarihi - Ay
        public String? ExpirationYear { get; set; } // Son kullanma tarihi - Yıl
        public String? Cvv { get; set; } // CVV numarası
        public String? Status { get; set; } // Ödeme durumu (Başarılı, Başarısız vb.)
        public DateTime PaymentDate { get; set; } = DateTime.Now;// Ödeme tarihi
        public String? PaymentMethod { get; set; } // Ödeme yöntemi (Kredi Kartı, PayPal vb.)
    }
}