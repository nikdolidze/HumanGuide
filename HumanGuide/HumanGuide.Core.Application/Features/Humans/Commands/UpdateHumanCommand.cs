using AutoMapper;
using FluentValidation;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using static HumanGuide.Core.Application.Features.Humans.Commands.UploadImageCommand;

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
        public class Validator : AbstractValidator<UpdateRequest>
        {
            private readonly IUnitOfWork unit;
            public Validator(IUnitOfWork unit)
            {
                this.unit = unit;

                RuleFor(x => x.FirstName).MaximumLength(50).MinimumLength(2)
                    .WithMessage("სახელი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 50 სიმბოლოს")
                    .NotNull().WithMessage("გთხოთ მიიუთითოთ სახელი")
                    .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("სახელი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");

                RuleFor(x => x.LastName).MaximumLength(50).MinimumLength(2)
                      .NotNull().WithMessage("გთვთ მიიუთითოთ გვარი")
                      .WithMessage("სახელი უნდა შეიცავდეს მინიმუმ 2 და მაქსიმუმ 50 სიმბოლოს")
                      .Matches("^[a-zA-Z]*$|^[ა-ჰ]*$").WithMessage("სახელი უნდა შეიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");

                RuleFor(x => x.Gender).NotNull().WithMessage("გთხოვთ მიუთითოთ სქესი");

                RuleFor(x => x.PersonalNo)
                       .NotNull().WithMessage("პირადი ნომერი ცარიელია")
                       .Length(11).WithMessage("პირადი ნომერი უნდა შედგებოდეს 11 სიმბოლოსგან")
                        .Matches("^[0-9]*$").WithMessage("პირადი ნომერი უნდა შედგებოდეს მხოლოდ ციფრებისგან");

                RuleFor(x => x.DarteOfBirth)
                       .Must(d => d.AddYears(18) < DateTime.Now).WithMessage("ფიზიკური პირი უნდა იყოს მინიმუმ 18 წლის");

                RuleFor(x => x.CityId)
                   .MustAsync(IfExistCity).WithMessage("მიუთითეთ ქალაქი სწორად");

                RuleFor(x => x.Phones.Select(x => x.Number))
                    .MustAsync(ValidatePhoneNumbe).WithMessage("ნომერი უნდა შეიცავდეს მინიმუმ 4 და მაქსიმუმ 50 სიმბოლოს");

            }
            private async Task<bool> ValidatePhoneNumbe(IEnumerable<string> numbers, CancellationToken cancellationToken)
            {
                List<bool> list = new();
                foreach (var number in numbers)
                {
                    list.Add(number.Length >= 4 && number.Length <= 50);
                }
                return  list.Any(x =>x== true);   
            }

            private async Task<bool> IfExistCity(int cityId, CancellationToken cancellationToken)
            {
                return await unit.CityRepository.CheckAsync(x => x.Id == cityId);
            }
        }
    }
}
