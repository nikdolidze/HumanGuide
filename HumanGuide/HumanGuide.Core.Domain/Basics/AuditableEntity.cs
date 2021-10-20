using System;

namespace HumanGuide.Core.Domain.Basics
{
    public abstract class AuditableEntity : BaseEntity
    {
        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public virtual int? CreatedBy { get; set; }
        public virtual int? DateUpdated { get; set; }
        public virtual int? UpdatedBy { get; set; }
        public virtual int? DateDeleted { get; set; }
        public virtual int? DeletedBy { get; set; }
    }
}
