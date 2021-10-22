using HumanGuide.Core.Application.Features.Humans.Commands;
using HumanGuide.Core.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace HumanGuide.Presentation.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HumanController : ControllerBase
    {
        private readonly IMediator mediator;
        public HumanController(IMediator mediator) =>
            this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        [HttpPost]
        public async Task Create([FromBody] CreateHumanCommand.Request request)
        {
            await mediator.Send(request);
        }

        [HttpPut]
        public async Task Update([FromBody] UpdateHumanCommand.UpdateRequest request)
        {
            await mediator.Send(request);
        }

        [HttpPut]
        [Route("UploadImage")]
        public async Task UploadImage([FromForm] UploadImageCommand.Requset requset)
        {
            await mediator.Send(requset);

        }
      

    }
}
