using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitness_tracker_service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fitness_tracker_service.Controllers
{
    [Route("api/Cheatmeal")]
    [ApiController]
    public class CheatmealController : ControllerBase
    {
        private readonly ILogger<CheatmealController> _logger;
        private readonly IMediator _mediator;

        public CheatmealController(ILogger<CheatmealController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCheatmeals")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllCheatmealQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetCheatmealById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetCheatmealByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
