using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
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

                // DOTO Reflection-ით უნდა წამოვიღო Human-ის კოლექციის ტიპის ველები და თუ ბრმა აქვს reqquest.id-ისთან წავშალო


                return Unit.Value;
            }

        }

    }
}
