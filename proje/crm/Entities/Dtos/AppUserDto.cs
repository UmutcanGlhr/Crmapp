namespace Entities.Dtos
{
    public record AppUserDto
    {
        public String? AD { get; init; }
        public String? SOYAD { get; init; }
        public String? FirmaAdi { get; init; }
        public String? TcKimlik { get; init; }
        public int DogumYili { get; set; }
        public String? VergiNo { get; init; }
        public String? FirmaLogo { get; set; }
        public String? Şehir { get; init; }
        public String? İlçe { get; init; }
        public String? TamAdres { get; init; }
        public String? VergiDairesi { get; init; }
        public bool aktive { get; init; } = false;
        public int? ranking { get; init; } = 0;
        public String? uzmanlikAlani { get; set; }
        public String? Biyografi { get; set; }
        public bool ShowCase { get; set; }
        public String? baslangic { get; set; }
        public String? bitis { get; set; }
        public int categoryID { get; init; }
    }
}