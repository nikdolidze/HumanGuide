using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Application.DTOs
{
    public class SetConnectedHumanDto
    {
        public HumanConnectionType ConnectionType { get; set; }

        public int ConnectedHumanId { get; set; }
    }
}
