using System.ComponentModel.DataAnnotations;

namespace Entities.Models
{
    public class Contact
    {
       
        public String? ContactID { get; set; }
        [Required(ErrorMessage = "Ad alanı boş olamaz.")]
        public String? isim { get; set; }

        [Required(ErrorMessage = "Mail alanı boş olamaz.")]
        public String? Email { get; set; }

        [Required(ErrorMessage = "Konu alanı boş olamaz.")]
        public String? Konu { get; set; }
        [Required(ErrorMessage = "Mesaj alanı boş olamaz.")]
        public String? Mesaj { get; set; }
    }
}