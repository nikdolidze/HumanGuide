using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Queries
{
    public class GetHumansQuery
    {
        public class Request : IRequest<GetHumanDto>
        {
            public int Id { get; private set; }

            public Request(int id) => this.Id = id;

        }
        public class Handler : IRequestHandler<Request, GetHumanDto>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<GetHumanDto> Handle(Request request, CancellationToken cancellationToken)
            {
                var human = await unit.HumanRepository.ReadAsync(request.Id);
                if (human == null)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                return await Task.FromResult(mapper.Map<GetHumanDto>(human));
            }
        }
    }
}
