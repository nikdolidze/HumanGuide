using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HumanGuide.Core.Domain.Entities
{
    public class Human : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public List<Phone> Phones { get; set; }
        public List<ConnecteHuman> ConnecteHumans { get; set; }
    }
}
