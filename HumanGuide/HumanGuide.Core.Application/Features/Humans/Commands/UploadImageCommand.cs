using AutoMapper;
using HumanGuide.Core.Application.Exceptions;
using HumanGuide.Core.Application.Interfaces;
using HumanGuide.Core.Application.Interfaces.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
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
            private readonly IImageService imageService;

            public Handler(IUnitOfWork unit, IMapper mapper, IImageService imageService)
            {
                this.unit = unit;
                this.mapper = mapper;
                this.imageService = imageService;
            }

            public async Task<Unit> Handle(Requset request, CancellationToken cancellationToken)
            {

                var humanDb = await unit.HumanRepository.ReadAsync(request.HumanId);
                if (humanDb == null)
                    throw new EntityNotFoundException("ჩანაწერი ვერ მოიძებნა");

                humanDb.ImageAddress = await imageService.UploadImage(request.Image);
                await unit.HumanRepository.UpdateAsync(humanDb);

                return Unit.Value;
            }
        }
    }
}
