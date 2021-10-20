using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Domain.Entities
{
    public class ConnecteHuman : AuditableEntity
    {
        public HumanConnectionType ConnectionType { get; set; }
        public int ConnecteHumanId { get; set; }
        public int HumanId { get; set; }
        public Human Human { get; set; }
    }
}