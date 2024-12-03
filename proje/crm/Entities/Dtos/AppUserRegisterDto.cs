using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Entities.Dtos
{
    public class AppUserRegisterDto
    {
        public String? UserName { get; set; }
        public String? Email { get; set; }
        public String? Password { get; set; }
        public String? PhoneNumber { get; set; }
        public String? AD { get; set; }
        public String? SOYAD { get; set; }
         public int DogumYili { get; set; }
        public String? FirmaAdi { get; set; }
        public String? TcKimlik { get; set; }
        public String? VergiNo { get; set; }
        public String? VergiDairesi { get; set; }
        public String? FirmaLogo { get; set; }
        public String? Şehir { get; set; }
        public String? İlçe { get; set; }
        public String? TamAdres { get; set; }

        public bool aktive { get; set; } = false;
        public int categoryID { get; set; }

    }
}