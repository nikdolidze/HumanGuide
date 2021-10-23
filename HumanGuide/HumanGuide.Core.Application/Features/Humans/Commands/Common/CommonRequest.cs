﻿using FluentValidation;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class CommonRequest : IRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Gender Gender { get; set; }
        public string PersonalNo { get; set; }
        public DateTime DarteOfBirth { get; set; }
        public int CityId { get; set; }
        public ICollection<SetPhoneDto> Phones { get; set; }
    }



    public class CommonValidator<T> : AbstractValidator<T> where T : CommonRequest
    {
        private readonly IUnitOfWork unit;
        public CommonValidator(IUnitOfWork unit)
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
                .Must(ValidatePhoneNumbe).WithMessage("ნომერი უნდა შეიცავდეს მინიმუმ 4 და მაქსიმუმ 50 სიმბოლოს");

        }
        private bool ValidatePhoneNumbe(IEnumerable<string> numbers)
        {
            List<bool> list = new();
            foreach (var number in numbers)
            {
                list.Add(number.Length >= 4 && number.Length <= 50);
            }
            return list.Any(x => x == true);
        }

        private async Task<bool> IfExistCity(int cityId, CancellationToken cancellationToken)
        {
            return await unit.CityRepository.CheckAsync(x => x.Id == cityId);
        }

    }

}