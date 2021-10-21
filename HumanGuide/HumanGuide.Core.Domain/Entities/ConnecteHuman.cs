using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Domain.Entities
{
    public class ConnecteHuman : AuditableEntity
    {
        public HumanConnectionType ConnectionType { get; set; }

        public uint ConnecteHumanId { get; set; }
        public Human ConnecteHumans { get; set; }
        public uint HumanId { get; set; }
        public Human Humans { get; set; }
    }
}