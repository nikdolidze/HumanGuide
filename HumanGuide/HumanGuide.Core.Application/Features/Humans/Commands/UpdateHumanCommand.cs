using AutoMapper;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class UpdateHumanCommand
    {
        public class UpdateRequest : CommonRequest
        {
            public int Id { get; set; }

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

                /// უნდა დავადო შეზღუდვა, რომ პერსონალზე ტიპის მიხედვით მხოლოდ 1 ტელეფონის მითითებაა შესაძლებელი
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
        public class Validator : CommonValidator<UpdateRequest>
        {
            public Validator(IUnitOfWork unit) : base(unit) { }
        }
    }
}
