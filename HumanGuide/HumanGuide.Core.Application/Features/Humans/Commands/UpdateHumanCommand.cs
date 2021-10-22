using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class UpdateHumanCommand
    {
        public class UpdateRequest : IRequest
        {
            public int Id { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public string PersonalNo { get; set; }
            public DateTime DarteOfBirth { get; set; }
            public int CityId { get; set; }
            public ICollection<SetPhoneDto> Phones { get; set; }
        }
        public class Handler : IRequestHandler<UpdateRequest>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }
            public async Task<Unit> Handle(UpdateRequest request, CancellationToken cancellationToken)
            {
                var humanDb = await unit.HumanRepository.ReadAsync(request.Id);
                var human = mapper.Map<Human>(request);
                await unit.HumanRepository.UpdateAsync(human.Id, human);


                /// უნდა დავადო შეზღუდვა, რომ პერსონალზე ტიპის მიხედვით მხოლოდ 1 ტელეფონის მითითევბაა შესაძლებელი
                var phonesDb = (await unit.Human2PhoneRepository.ReadAsync(x => x.HumanId == request.Id)).Select(x => x.Phone);
                if (!(request.Phones != null && request.Phones.Any()))
                    return Unit.Value;
                foreach (var newPhone in request.Phones)
                {
                    foreach (var phoneDb in phonesDb)
                    {
                        if (newPhone.Type == phoneDb.Type)
                        {
                            var PhoneDb = await unit.PhoneRepository.ReadAsync(phoneDb.Id);
                            PhoneDb.Number = newPhone.Number;
                            await unit.PhoneRepository.UpdateAsync(PhoneDb);
                        }
                    }
                }

                return Unit.Value;
            }
        }
    }
}
