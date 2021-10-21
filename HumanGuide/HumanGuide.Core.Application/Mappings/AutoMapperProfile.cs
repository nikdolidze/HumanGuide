using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Core.Application.Mappings
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SetPhoneDto, Phone>();
            CreateMap<SetCityDto, City>();
        }
    }
}
