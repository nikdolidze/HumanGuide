using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class PhoneConfiguration : IEntityTypeConfiguration<Phone>
    {
        public void Configure(EntityTypeBuilder<Phone> builder)
        {
            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);
        }
    }
}
