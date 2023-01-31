using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class DeleteHumanCommand
    {
        public class Request : IRequest
        {
            public int Id { get; private set; }
            public Request(int id) => this.Id = id;
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;

            public Handler(IUnitOfWork unit)
            {
                this.unit = unit;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                var human = await unit.HumanRepository.ReadAsync(request.Id);
                if (human == null)
                    throw new EntityNotFoundException("მიუთითეთ აიდი ბენეფიციარი სწორად");

                await unit.HumanRepository.DeleteAsync(human);

                var humanInConnectedhuman = await unit.ConnectedHumanRepository.ReadAsync(x => x.BaseConnectedHumanId == request.Id);
                if (humanInConnectedhuman.Any())
                    await unit.ConnectedHumanRepository.DeleteRangeAsync(humanInConnectedhuman);

                return Unit.Value;
            }
        }
    }
}
