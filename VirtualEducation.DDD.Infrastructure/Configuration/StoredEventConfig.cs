using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using VirtualEducation.DDD.Domain.Generics;

namespace VirtualEducation.DDD.Infrastructure.Configuration
{
    public class StoredEventConfig : IEntityTypeConfiguration<StoredEvent>
    {
        public void Configure(EntityTypeBuilder<StoredEvent> builder)
        {
            builder.ToTable("StoredEvents");

            builder.HasKey(p => p.StoredId);
        }
    }
}
