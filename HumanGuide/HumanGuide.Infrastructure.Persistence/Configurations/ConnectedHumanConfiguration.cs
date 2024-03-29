﻿using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HumanGuide.Infrastructure.Persistence.Configurations
{
    class ConnectedHumanConfiguration : IEntityTypeConfiguration<ConnectedHuman>
    {
        public void Configure(EntityTypeBuilder<ConnectedHuman> builder)
        {
            builder.ToTable("ConnectedHumans");

            builder.HasQueryFilter(x => !x.DateDeleted.HasValue);

            builder.HasOne(x => x.Human)
                .WithMany(x => x.BaseConnectedHumans)
                .HasForeignKey(x => x.HumanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(x => x.BaseConnectedHuman)
                .WithMany()
                .HasForeignKey(x => x.BaseConnectedHumanId)
                .OnDelete(DeleteBehavior.Cascade);

            //DOTO : თუ OnDelete(DeleteBehavior.NoAction-ს არ დავწერ მიგრაცია ურყტამს ერორს. გასარკვევი მაქვს საჭიროა თუ არა ეს მეთოდი/რატო არტყამს ერორს;
        }
    }
}
