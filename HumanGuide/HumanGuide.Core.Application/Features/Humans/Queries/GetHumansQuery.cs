using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Queries
{
    public class GetHumansQuery
    {
        public class GetAllRequest : IRequest<GetPaginationDto<GetHumanDto>>
        {
            public int PageIndex { get; set; } = 1;
            public int PageSize { get; set; } = 10;

            public string PersonalNo { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }
        public class Handler : IRequestHandler<GetAllRequest, GetPaginationDto<GetHumanDto>>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<GetPaginationDto<GetHumanDto>> Handle(GetAllRequest request, CancellationToken cancellationToken)
            {
                var humans = await unit.HumanRepository.FilterAsync(request.PageIndex, request.PageSize, request.PersonalNo, request.FirstName, request.LastName);

                return mapper.Map<GetPaginationDto<GetHumanDto>>(humans);
            }
        }
    }
}
