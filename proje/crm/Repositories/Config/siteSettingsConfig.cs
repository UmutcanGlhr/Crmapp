using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class siteSettingsConfig : IEntityTypeConfiguration<SiteSettings>
    {
        public void Configure(EntityTypeBuilder<SiteSettings> builder)
        {
            builder.HasKey(c=>c.siteID);
            builder.HasData(
                new SiteSettings() {siteID=1,siteAdi="Randevu BUL",siteMail="umcbilisim@gmail.com",hakkimizda="hedefimiz zaman ve herkes zamanini planlasin",siteNumber="05526734412",siteInstagram="umcbilisim",siteLinkedin="umcbilisim",copyright="bu sitenin telif haklari umcbilisime aittir"}
            );
        }
    }
}