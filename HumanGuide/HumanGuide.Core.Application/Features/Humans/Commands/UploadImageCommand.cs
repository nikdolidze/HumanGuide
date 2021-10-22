using AutoMapper;
using HumanGuide.Core.Application.Hepler;
using HumanGuide.Core.Application.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading;
using System.Threading.Tasks;

namespace HumanGuide.Core.Application.Features.Humans.Commands
{
    public class UploadImageCommand
    {
        public class Requset : IRequest
        {
            public int HumanId { get; set; }

            [NotMapped]
            public IFormFile Image { get; set; }
        }
        public class Handler : IRequestHandler<Requset>
        {
            private readonly IUnitOfWork unit;
            private readonly IMapper mapper;

            public Handler(IUnitOfWork unit, IMapper mapper)
            {
                this.unit = unit;
                this.mapper = mapper;
            }

            public async Task<Unit> Handle(Requset request, CancellationToken cancellationToken)
            {

                var humanDb = await unit.HumanRepository.ReadAsync(request.HumanId);
                if (humanDb == null)
                    throw new Exception("ჩანაწერი ვერ მოიძებნა");

                humanDb.ImageAddress = (await HelperClass.UploadImage(request.Image));
                await unit.HumanRepository.UpdateAsync(humanDb);

                return Unit.Value;
            }
        }
    }
}
