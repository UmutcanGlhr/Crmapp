using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.Config
{
    public class MeetSlotConfig : IEntityTypeConfiguration<MeetSlot>
    {
        public void Configure(EntityTypeBuilder<MeetSlot> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Date).IsRequired();
            builder.Property(c => c.Time).IsRequired();

            builder.HasData(
                new MeetSlot() { Id = 1, Date=" ", Time=" "}
            );
        }
    }
}