namespace Entities.Dtos
{
    public record siteSettingsDto
    {
        public int siteID { get; init; }
        public String? siteAdi { get; init; }
        public String? siteMail { get; init; }
        public String? hakkimizda { get; init; }
        public String? siteNumber { get; init; }
        public String? siteInstagram { get; init; }
        public String? siteLinkedin { get; init; }
        public String? copyright { get; init; }

        public String? ImgUrl { get; set; }
        public String? ImgUrl2 { get; set; }
        public String? ImgUrl3 { get; set; }
        public String? ImgUrl4 { get; set; }
    }
}