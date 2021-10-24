using AutoMapper;
using HumanGuide.Core.Application.Common;
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
            CreateMap<Phone, GetPhoneDto>()
              .ForMember(dest => dest.Type, opt => opt.MapFrom(src =>
              src.Type.Use(x => x == PhoneType.Home || x == PhoneType.Mobile ? x == PhoneType.Mobile ? "მობილური" : "სახლი" : "ოფისი")));

            CreateMap<SetCityDto, City>();
            CreateMap<City, GetCityDto>();


            CreateMap<CreateHumanCommand.Request, Human>()
            .ForMember(x => x.City, y => y.Ignore()).ForMember(x => x.BaseConnectedHumans, y => y.Ignore());
            CreateMap<UpdateHumanCommand.UpdateRequest, Human>();
            CreateMap<Human, GetHumanDto>();


            CreateMap<SetHuman2PhoneDto, Human2Phone>();
            CreateMap<Human2Phone, GetHuman2PhoneDto>();


            CreateMap<CreateConnectedHuman.CreateRequest, ConnectedHuman>();
            CreateMap<ConnectedHuman, GetConnectedHumanDto>();

            CreateMap(typeof(Pagination<>), typeof(GetPaginationDto<>));

        }

    }
}
