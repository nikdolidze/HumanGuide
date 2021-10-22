using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Application.DTOs
{
    public class SetConnecteHumanDto
    {
        public HumanConnectionType ConnectionType { get; set; }

        public int ConnecteHumanId { get; set; }
    }
}
