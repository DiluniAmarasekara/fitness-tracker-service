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
    [Route("api/Goal")]
    [ApiController]
    public class GoalController : ControllerBase
    {
        private readonly ILogger<GoalController> _logger;
        private readonly IMediator _mediator;

        public GoalController(ILogger<GoalController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet("{id}", Name = "GetGoalById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetGoalByIdQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
