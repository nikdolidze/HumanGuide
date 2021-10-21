using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class ConnecteHumanConfiguration : IEntityTypeConfiguration<ConnecteHuman>
    {
        public void Configure(EntityTypeBuilder<ConnecteHuman> builder)
        {
            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);
        }
    }
}
