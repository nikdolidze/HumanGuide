using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;
using System.Collections.Generic;

namespace HumanGuide.Core.Domain.Entities
{
    public class Phone : AuditableEntity
    {
        public PhoneType Type { get; set; }
        public string Number { get; set; }
        public ICollection<Human2Phone> Human2Phones { get; set; }

    }
}
