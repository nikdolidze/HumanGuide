using AutoMapper;
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
            public int ConnecteHumanId { get; set; }
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
                    throw new Exception("ფიზიკური პირი ვერ მოიძებნა");

                var connectedhuman = await unit.ConnecteHumanRepository.CheckAsync(x => x.HumanId == request.HumanId && x.ConnectionType == request.ConnectionType && x.ConnecteHumanId == request.ConnecteHumanId);
                if (connectedhuman)
                    throw new Exception("დაკავშირებული უკვე დამატებულია");

                var connectedHumanDb = mapper.Map<ConnecteHuman>(request);
                connectedHumanDb.HumanId = request.HumanId;
                await unit.ConnecteHumanRepository.CreateAsync(connectedHumanDb);
                return Unit.Value;
            }
        }
    }
}
