using HumanGuide.Core.Domain.Enums;
using System;
using System.Collections.Generic;

namespace HumanGuide.Core.Application.DTOs
{
    public class GetHumanDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ImageAddress { get; set; }
        public GetCityDto City { get; set; }
        public ICollection<GetHuman2PhoneDto> Human2Phones { get; set; }
        public ICollection<GetConnectedHumanDto> ConnectedHumans { get; set; }
    }
}
