using System;

namespace HumanGuide.Core.Domain.Basics
{
    public abstract class AuditableEntity : BaseEntity
    {
        // TODO : CreatedBy,UpdatedBy,DeletedBy-ის ტიპი, მანამ სანამ იუზერმენეჯმენტის დამატება მოხდება არის სტრინგი, რათა შევძლო PC-ის UserName-ის ჩაწერა.
        public virtual DateTime DateCreated { get; set; } = DateTime.UtcNow;
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? DateUpdated { get; set; }
        public virtual string UpdatedBy { get; set; }
        public virtual DateTime? DateDeleted { get; set; }
        public virtual string DeletedBy { get; set; }


      


    }
}
