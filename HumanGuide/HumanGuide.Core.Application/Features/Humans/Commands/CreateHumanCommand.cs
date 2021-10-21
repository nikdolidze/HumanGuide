using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Interfaces.Repositories;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
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
            public SetCityDto City { get; set; }
            public SetPhoneDto Phone { get; set; }
            public string Image { get; set; }
            public List<int> ConnectedPersons { get; set; }
        }
        public class Handler : IRequestHandler<Request>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<Unit> Handle(Request request, CancellationToken cancellationToken)
            {




                return Unit.Value;
            }
        }

    }
}
