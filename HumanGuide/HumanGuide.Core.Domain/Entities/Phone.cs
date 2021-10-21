using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Domain.Entities
{
    public class Phone : AuditableEntity
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
        public uint HumanId { get; set; }
        public Human Human { get; set; }
    }
}
