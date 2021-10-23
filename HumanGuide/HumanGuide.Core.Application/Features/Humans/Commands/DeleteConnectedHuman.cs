﻿using HumanGuide.Core.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class DeleteConnectedHuman
    {
        public class DeleteRequest : IRequest
        {
            public int Id { get; private set; }
            public DeleteRequest(int id) => this.Id = id;
        }
        public class Handler : IRequestHandler<DeleteRequest>
        {
            private readonly IUnitOfWork unit;

            public Handler(IUnitOfWork unit)
            {
                this.unit = unit;
            }
            public async Task<Unit> Handle(DeleteRequest request, CancellationToken cancellationToken)
            {
                var connectedHuman = await unit.ConnecteHumanRepository.ReadAsync(request.Id);
                if (connectedHuman == null)
                    throw new Exception("ჩანაწერი ვერ მოიძებნა");
                await unit.ConnecteHumanRepository.DeleteAsync(connectedHuman);

                return Unit.Value;
            }

        }
    }
}
