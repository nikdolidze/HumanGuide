using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Features.Humans.Commands;
using HumanGuide.Core.Domain.Entities;

namespace HumanGuide.Core.Application.Mappings
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<SetPhoneDto, Phone>().ReverseMap();
            CreateMap<SetCityDto, City>();

            //დროებითია ეს CreateMap
            CreateMap<CreateHumanCommand.Request, Human>()
            .ForMember(x => x.City, y => y.Ignore())
            .ForMember(x => x.ConnecteHumans, y => y.Ignore());

            CreateMap<SetHuman2PhoneDto, Human2Phone>();

            CreateMap<UpdateHumanCommand.UpdateRequest, Human>();
        }

    }
}
