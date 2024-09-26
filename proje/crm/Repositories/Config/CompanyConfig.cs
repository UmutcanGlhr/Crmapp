using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
namespace Repositories.Config
{
    public class CompanyConfig : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(c => c.companyID);
            builder.Property(c => c.companyName).IsRequired();

            builder.HasData(
                new Company() { companyID = 1, companyName = "GüvenPC" ,categoryId=1}

            );
        }
    }
}