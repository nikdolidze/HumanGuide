using HumanGuide.Core.Domain.Basics;
using System.Collections.Generic;

namespace HumanGuide.Core.Domain.Entities
{
    public class City : AuditableEntity
    {
        public string Name { get; set; }
        public List<Human> Humans { get; set; }
    }
}