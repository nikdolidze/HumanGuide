using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Infrastructure.Persistence
{
    public class DataContext : DbContext
    {

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Human> Humans { get; set; }

        #region SaveChanges -ების გადატვირთვა
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChangesAsync(cancellationToken);
        }
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
                this.Audition(entry);

            return base.SaveChanges();
        }
        private void Audition(EntityEntry<AuditableEntity> entry)
        {  
            // TODO  : user-ის მინიჭება იუზერმენეჯმენტის დამატების შემდეგ უნდა შეიცვალოს.
            var user = Environment.UserName;
            switch (entry.State)
            {
                case EntityState.Added:
                    //entry.Entity.DateCreated = DateTime.Now;
                    entry.Entity.CreatedBy = user;
                    break;
                case EntityState.Modified:
                    entry.Entity.DateUpdated = DateTime.UtcNow;
                    entry.Entity.UpdatedBy = user;

                    // არ შეიცვლება ქვემოთ ჩამოთვლილი ველები
                    entry.Property(nameof(AuditableEntity.CreatedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateCreated)).IsModified = false;

                    entry.Property(nameof(AuditableEntity.DeletedBy)).IsModified = false;
                    entry.Property(nameof(AuditableEntity.DateDeleted)).IsModified = false;
                    break;
                case EntityState.Deleted:
                    entry.State = EntityState.Unchanged;

                    // შეიცვლება მხოლოდ ქვემოთ ჩამოთვლილი ველები
                    entry.Entity.DateDeleted = DateTime.UtcNow;
                    entry.Entity.DeletedBy = user;
                    break;
            };
        }
        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        
        }

    }
}
