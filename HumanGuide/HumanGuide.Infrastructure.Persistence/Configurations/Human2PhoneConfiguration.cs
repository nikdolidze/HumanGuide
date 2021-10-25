using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class Human2PhoneConfiguration : IEntityTypeConfiguration<Human2Phone>
    {
        public void Configure(EntityTypeBuilder<Human2Phone> builder)
        {
            builder.ToTable("Human2Phones");

            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);
        }
    }
}

