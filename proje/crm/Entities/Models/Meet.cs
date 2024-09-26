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
        [Required(ErrorMessage = "adres is required.")]
        public String? Adres { get; set; } = String.Empty;
        [Required(ErrorMessage = "Description is required.")]
        public String? Description { get; set; } = String.Empty;
        public bool active { get; set; } = true;

        [Required(ErrorMessage = "tarih is required.")]
        public DateTime tarih { get; set; }
        public int? CompanyID { get; set; } // foregin key
        public Company? company { get; set; } //Navigation Property
        [Required(ErrorMessage = "company is required.")]
        public String? userID { get; set; }

    }
}