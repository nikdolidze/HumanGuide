using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Hepler;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class CreateHumanCommand
    {
        public class Request : CommonRequest
        {
            public ICollection<SetConnectedHumanDto> ConnectedHumans { get; set; }
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
                var existHumanRersonelNo = await unit.HumanRepository.CheckAsync(x => x.PersonalNo == request.PersonalNo);
                if (existHumanRersonelNo)
                    throw new EntityAlreadyExistException("ჩანაწერი იგივე პირადი ნომრით უკვე არსეობს");

                //თუ მითითებულია დაკავშირებული პირი და ეს პირი არსებობს Human თეიბლში
                var connectedHumansIsNotNull = request.ConnectedHumans != null && request.ConnectedHumans.Any();
                if (connectedHumansIsNotNull)
                {
                    foreach (var connectedHuman in request.ConnectedHumans)
                    {
                        var existHuman = await unit.HumanRepository.CheckAsync(x => x.Id == connectedHuman.BaseConnectedHumanId);
                        if (!existHuman)
                            throw new EntityNotFoundException("დაკავშირებული პირი დარეგისტრირებული უნდა იყოს რეესტრში");
                    }
                }


                // Human-ის შექმნა
                var human = mapper.Map<Human>(request);
                await unit.HumanRepository.CreateAsync(human);

                // Phone-ის ფამატება
                if (request.Phones != null && request.Phones.Any())
                {
                    var phonesDb = mapper.Map<IEnumerable<Phone>>(request.Phones);
                    await unit.PhoneRepository.CreaRangeteAsync(phonesDb);
                    // Human2Phones-ის შექმნა
                    var human2Phones = HelperClass.CreateListOfHuman2Phone(human.Id, phonesDb.Select(x => x.Id).ToList());
                    await unit.Human2PhoneRepository.CreaRangeteAsync(human2Phones);
                }

                if (connectedHumansIsNotNull)
                {
                    // ConnectedHumans-ის შექმნა
                    var connectedHumans = HelperClass.CreateListOfConnectedHuman(human.Id, request.ConnectedHumans.ToList());
                    await unit.ConnectedHumanRepository.CreaRangeteAsync(connectedHumans);
                }

                return Unit.Value;
            }
        }
        public class Validator : CommonValidator<Request>
        {
            public Validator(IUnitOfWork unit) : base(unit) { }
        }
    }
}
