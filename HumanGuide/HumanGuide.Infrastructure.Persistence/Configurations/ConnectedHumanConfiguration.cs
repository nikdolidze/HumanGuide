using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class ConnectedHumanConfiguration : IEntityTypeConfiguration<ConnecteHuman>
    {
        public void Configure(EntityTypeBuilder<ConnecteHuman> builder)
        {
            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);


            builder.HasOne(x => x.Humans)
                .WithMany(x => x.ConnecteHumans)
                .HasForeignKey(x => x.ConnecteHumanId)
                .OnDelete(DeleteBehavior.NoAction);
            // DOTO : თუ OnDelete(DeleteBehavior.NoAction-ს არ დავწერ მიგრაცია ურყტამს ერორს. გასარკვევი მაქვს საჭიროა თუ არა ეს მეთოდი/რატო არტყამს ერორს;
        }
    }
}
