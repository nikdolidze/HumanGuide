using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);

            builder.Property(x => x.Name).IsRequired();
        }
    }
}
