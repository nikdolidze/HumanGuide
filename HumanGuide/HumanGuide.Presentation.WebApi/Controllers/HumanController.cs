using HumanGuide.Core.Application.Features.Humans.Commands;
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
    }
}
