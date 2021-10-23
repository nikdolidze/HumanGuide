using AutoMapper;
using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class CreateConnectedHuman
    {
        public class CreateRequest : IRequest
        {
            internal int HumanId { get; set; }
            public int ConnectedHumanId { get; set; }
            public HumanConnectionType ConnectionType { get; set; }
            public void SetId(int id)
            {
                this.HumanId = id;
            }
        }
        public class Handler : IRequestHandler<CreateRequest>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<Unit> Handle(CreateRequest request, CancellationToken cancellationToken)
            {
                var human = await unit.HumanRepository.ReadAsync(request.HumanId);
                if (human == null)
                    throw new EntityNotFoundException("ფიზიკური პირი ვერ მოიძებნა");
                var connectedHuman = await unit.HumanRepository.CheckAsync(x => x.Id == request.ConnectedHumanId);
                if (!connectedHuman)
                    throw new EntityNotFoundException("დაკავშირებული პირი დამატებული უნდა იყოს ფიზიკური პირების რეესტრში");

                var connectedhuman = await unit.ConnectedHumanRepository.CheckAsync(x => x.HumanId == request.HumanId && x.ConnectionType == request.ConnectionType && x.BaseConnectedHumanId == request.ConnectedHumanId);
                if (connectedhuman)
                    throw new EntityNotFoundException("დაკავშირებული უკვე დამატებულია");

                var connectedHumanDb = mapper.Map<ConnectedHuman>(request);
                connectedHumanDb.HumanId = request.HumanId;
                await unit.ConnectedHumanRepository.CreateAsync(connectedHumanDb);
                return Unit.Value;
            }
        }
    }
}
