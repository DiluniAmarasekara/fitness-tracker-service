using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
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

        [HttpPost]
        public async Task<IActionResult> post(long goal_id, double today_weight)
        {
            var result = await _mediator.Send(new LogTodayWeightCommand(goal_id, today_weight));
            return Created(DateTime.Now.ToString(), result);
        }

    }
}
