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
                


                // ქალაქის გადამოწმება ცნობარში
                var cityDb = await unit.CityRepository.ReadAsync(request.CityId);
                if (cityDb == null)
                    throw new EntityNotFoundException("მოუთითეთ ქალაქი სწორად");

                // Human-ის შექმნა
                var human = mapper.Map<Human>(request);
                human.City = cityDb;
                await unit.HumanRepository.CreateAsync(human);
                // Phone-ის ფამატება
                if (request.Phones != null && request.Phones.Any())
                {
                    var phones = mapper.Map<IEnumerable<Phone>>(request.Phones);
                    await unit.PhoneRepository.CreaRangeteAsync(phones);
                    // Human2Phones-ის შექმნა
                    var human2Phones = HelperClass.CreateListOfHuman2Phone(human.Id, phones.Select(x => x.Id).ToList());
                    await unit.Human2PhoneRepository.CreaRangeteAsync(human2Phones);
                    

                }

                if (request.ConnectedHumans != null && request.ConnectedHumans.Any())
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
