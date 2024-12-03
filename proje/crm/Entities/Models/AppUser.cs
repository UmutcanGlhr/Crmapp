using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Entities.Models
{
    public class AppUser : IdentityUser
    {
        public String? AD { get; set; }
        public String? SOYAD { get; set; }

        public String? FirmaAdi { get; set; }
        public String? TcKimlik { get; set; }
        public int DogumYili { get; set; }
        public String? VergiNo { get; set; }
        public String? FirmaLogo { get; set; }

        public String? Şehir { get; set; }

        public String? İlçe { get; set; }

        public String? TamAdres { get; set; }
        public String? VergiDairesi { get; set; }
        public bool aktive { get; set; } = false;
        public int categoryID { get; set; }
        public int? ranking { get; set; } = 0;
        public String? uzmanlikAlani { get; set; }
        public String? Biyografi { get; set; }
        public bool ShowCase { get; set; }
        public String? baslangic { get; set; }
        public String? bitis { get; set; }  


    }
}