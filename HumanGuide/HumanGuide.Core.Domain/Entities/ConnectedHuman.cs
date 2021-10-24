using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Domain.Entities
{
    public class ConnectedHuman : AuditableEntity
    {
        public HumanConnectionType ConnectionType { get; set; }

        public int BaseConnectedHumanId { get; set; }
        public Human BaseConnectedHuman { get; set; }

        public int HumanId { get; set; }
        public Human Human { get; set; }
    }
}