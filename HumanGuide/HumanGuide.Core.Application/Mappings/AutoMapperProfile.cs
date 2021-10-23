using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Features.Humans.Commands;
using HumanGuide.Core.Application.Hepler.Extenssion;
using HumanGuide.Core.Domain.Entities;
using HumanGuide.Core.Domain.Enums;

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

            CreateMap<CreateConnectedHuman.CreateRequest, ConnecteHuman>();

            CreateMap<Human, GetHumanDto>();
            CreateMap<City, GetCityDto>();

            CreateMap<Human2Phone, GetHuman2PhoneDto>();
            CreateMap<Phone, GetPhoneDto>()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
               src.Type.Use(x => x == PhoneType.Home || x == PhoneType.Mobile ? x == PhoneType.Mobile ? "მობილური" : "სახლი" : "ოფისი")));

            CreateMap<ConnecteHuman, GetConnectedHumanDto>();
        }

    }
}
