using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class CreateHumanCommand
    {
        public class Request : IRequest
        {
            public string FisrtName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public string PersonalNo { get; set; }
            public DateTime DarteOfBirth { get; set; }
            public string Image { get; set; }
        }
        public class Handler : IRequestHandler<Request>
        {
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {
                return Unit.Value;
            }
        }

    }
}
