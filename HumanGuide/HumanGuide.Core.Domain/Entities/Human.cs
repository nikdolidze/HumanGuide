﻿using HumanGuide.Core.Domain.Basics;
using HumanGuide.Core.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HumanGuide.Core.Domain.Entities
{
    public class Human : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageAddress { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public ICollection<Human2Phone> Human2Phones { get; set; }
     //   [InverseProperty("BaseConnectedHuman")]
        public ICollection<ConnectedHuman> BaseConnectedHumans { get; set; }

     //   [InverseProperty("Human")]

        public ICollection<ConnectedHuman> Humans { get; set; }

    }

}
