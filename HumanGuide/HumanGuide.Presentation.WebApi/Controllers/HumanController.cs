using HumanGuide.Core.Application.DTOs;
using HumanGuide.Core.Application.Features.Humans.Commands;
using HumanGuide.Core.Application.Features.Humans.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static HumanGuide.Core.Application.Features.Humans.Queries.GetConnectedHumanReport;

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

        [HttpPut("CreateConnectedHuman/{humanId}")]
        public async Task CreateConnectedHuman(int humanId, [FromBody] CreateConnectedHuman.CreateRequest request)
        {
            request.SetId(humanId);
            await mediator.Send(request);
        }

        [HttpDelete("DeleteConnectedHuman/{id}")]
        public async Task DeleteConnectedHuman(int id)
        {
            await mediator.Send(new DeleteConnectedHuman.DeleteRequest(id));
        }

        [HttpDelete("DeleteHuman/{id}")]
        public async Task DeleteHuman(int id)
        {
            await mediator.Send(new DeleteHumanCommand.Request(id));
        }


        [HttpGet("{id}")]
        public async Task<GetHumanDto> Get([FromRoute] int id) =>
            await mediator.Send(new GetHumansQuery.Request(id));

        [HttpGet("Repost")]
        public async Task<List<Relation>> Get()
        {
          return   await mediator.Send(new GetConnectedHumanReport.Request());
        }
    }
}