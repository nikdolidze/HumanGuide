using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
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
                var connectedHuman = await unit.ConnectedHumanRepository.ReadAsync(request.Id);
                if (connectedHuman == null)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");
                await unit.ConnectedHumanRepository.DeleteAsync(connectedHuman);

                return Unit.Value;
            }

        }
    }
}
