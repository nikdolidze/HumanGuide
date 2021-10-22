﻿using AutoMapper;
using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Hepler;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Domain.Entities;
using HumanGuide.Core.Domain.Enums;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class CreateHumanCommand
    {
        public class Request : IRequest
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Gender Gender { get; set; }
            public string PersonalNo { get; set; }
            public DateTime DarteOfBirth { get; set; }
            public int City { get; set; }
            public ICollection<SetPhoneDto> Phones { get; set; }
            public ICollection<int> ConnecteHumanIds { get; set; }
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
                // TODO დასამატებელი შეზღუდვები და როლბექი

                // ქალაქის გადამოწმება ცნობარში
                var cityDb = await unit.CityRepository.ReadAsync(request.City);
                if (cityDb == null)
                    throw new Exception("მოუთითეთ ქალაქი სწორად");

                // Phone-ის ფამატება
                var phones = mapper.Map<IEnumerable<Phone>>(request.Phones);
                await unit.PhoneRepository.CreaRangeteAsync(phones);

                // Human-ის შექმნა
                var human = mapper.Map<Human>(request);
                human.City = cityDb;
                await unit.HumanRepository.CreateAsync(human);

                // Human2Phones-ის შექმნა
                var human2Phones = HelperClass.CreateListOfHuman2Phone(human.Id, phones.Select(x => x.Id).ToList());
                await unit.Human2PhoneRepository.CreaRangeteAsync(human2Phones);

                // ConnectedHumans-ის შექმნა
                var connectedHumans = HelperClass.CreateListOfConnecteHuman(human.Id, request.ConnecteHumanIds.ToList());
                await unit.ConnecteHumanRepository.CreaRangeteAsync(connectedHumans);

                

                return Unit.Value;
            }
            
        }
       

    }
}
