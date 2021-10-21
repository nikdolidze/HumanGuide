using HumanGuide.Core.Domain.Basics;

namespace HumanGuide.Core.Domain.Entities
{
    public class Human2Phone : AuditableEntity
    {
        public uint HumanId { get; set; }
        public Human Human { get; set; }

        public uint PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
