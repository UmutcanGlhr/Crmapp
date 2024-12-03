using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Meet
    {
        public int meetID { get; set; }
        [Required(ErrorMessage = "ad is required.")]
        public String? ad { get; set; } = String.Empty;
        public String? soyad { get; set; } = String.Empty;
        [Required(ErrorMessage = "telefon is required.")]
        public String? telefon { get; set; } = String.Empty;
        [Required(ErrorMessage = "Şehir is required.")]
        public String? Şehir { get; set; } = String.Empty;
        [Required(ErrorMessage = "ilçe is required.")]
        public String? ilçe { get; set; } = String.Empty;
        [Required(ErrorMessage = "adres is required.")]
        public String? Adres { get; set; } = String.Empty;
        [Required(ErrorMessage = "Description is required.")]
        public String? Description { get; set; } = String.Empty;
        public bool active { get; set; } = true;
        public String? userID { get; set; }
        public String? tarih { get; set; }
        public String? Saat { get; set; }

        public String? sorguKodu { get; set; }
        public int MeetSlotID { get; set; }

        public MeetSlot? MeetSlot { get; set; }

    }
}