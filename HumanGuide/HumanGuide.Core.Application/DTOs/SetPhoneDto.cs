using HumanGuide.Core.Domain.Enums;

namespace HumanGuide.Core.Application.DTOs
{
    public class SetPhoneDto
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
    }
}
