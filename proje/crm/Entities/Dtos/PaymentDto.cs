namespace Entities.Dtos
{
    public record PaymentDto
    {
        public int Id { get; init; } // Ödeme ID'si
        public String? UserID { get; set; }
        public int productId { get; set; }
        public String? Amount { get; init; } // Ödeme miktarı
        public String? CardHolderName { get; init; } // Kart üzerindeki isim
        public String? CardNumber { get; init; }  // Kart numarası
        public String? ExpirationMonth { get; init; } // Son kullanma tarihi - Ay
        public String? ExpirationYear { get; init; } // Son kullanma tarihi - Yıl
        public String? Cvv { get; init; }  // CVV numarası
        public String? Status { get; init; } // Ödeme durumu (Başarılı, Başarısız vb.)
        public DateTime PaymentDate { get; init; } = DateTime.Now;// Ödeme tarihi
        public String? PaymentMethod { get; init; } // Ödeme yöntemi (Kredi Kartı, PayPal vb.)
    }
}