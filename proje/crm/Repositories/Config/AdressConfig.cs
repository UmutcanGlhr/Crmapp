using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class AdressConfig : IEntityTypeConfiguration<Adress>
    {
        public void Configure(EntityTypeBuilder<Adress> builder)
        {
            builder.HasKey(c => c.AddressID);
            builder.Property(c => c.AddressName).IsRequired();

            builder.HasData(
                new Adress() { AddressID = 1, AddressName = "eskişehir" }

            );
        }
    }
}