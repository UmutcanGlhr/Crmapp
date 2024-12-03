using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace Repositories.Config
{
    public class MeetConfig : IEntityTypeConfiguration<Meet>
    {
        public void Configure(EntityTypeBuilder<Meet> builder)
        {
            builder.HasKey(c => c.meetID);
            builder.Property(c => c.ad).IsRequired();
            builder.Property(c => c.Adres).IsRequired();

            builder.HasData(
                new Meet() { meetID = 1, ad = "berkay", soyad = "ekit", telefon = "0513212313", Description = "format atilacak", Adres = "zafer tepe mh", Şehir = "kütahya", ilçe = "Merkez", MeetSlotID = 1 }
            );
        }
    }
}