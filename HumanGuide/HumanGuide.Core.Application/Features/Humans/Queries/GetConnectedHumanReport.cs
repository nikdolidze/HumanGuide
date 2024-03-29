﻿using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Queries
{
    public class GetConnectedHumanReport
    {
        public class Request : IRequest<List<Relation>>
        {
        }
        public class Handler : IRequestHandler<Request, List<Relation>>
        {
            private readonly IUnitOfWork unit;

            public Handler(IUnitOfWork unit)
            {
                this.unit = unit;
            }
            public async Task<List<Relation>> Handle(Request request, CancellationToken cancellationToken)
            {
                var connectedHumans = await unit.ConnectedHumanRepository.ReadAsync();

                var report = connectedHumans.GroupBy(x => x.HumanId).Select(groupedByHumanId =>
                {
                    var groupedByConnectionType = groupedByHumanId.GroupBy(x => x.ConnectionType);
                    var connections = groupedByConnectionType.Select(x => new Connection(x.Count(), x.Key)).ToList();
                    return new Relation(groupedByHumanId.Key, connections);
                }).ToList();

                return report;
            }
        }

        public class Relation
        {
            public Relation(int humanId, List<Connection> connections)
            {
                Connections = connections;
                HumanId = humanId;
            }
            public int HumanId { get; private set; }
            public List<Connection> Connections { get; private set; }
        }

        public class Connection
        {
            public Connection(int count, HumanConnectionType humanConnectionType)
            {
                Count = count;
                HumanConnectionType = humanConnectionType;
            }
            public int Count { get; private set; }
            public HumanConnectionType HumanConnectionType { get; private set; }
        }
    }
}
