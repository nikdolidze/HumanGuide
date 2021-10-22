using HumanGuide.Core.Domain.Basics;

namespace HumanGuide.Core.Domain.Entities
{
    public class Human2Phone : AuditableEntity
    {
        public int HumanId { get; set; }
        public Human Human { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
