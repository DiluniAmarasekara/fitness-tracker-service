using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_service.WebApi
{
    [Route("api/Workout")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly ILogger<WorkoutController> _logger;
        private readonly IMediator _mediator;

        public WorkoutController(ILogger<WorkoutController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllWorkouts")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllWorkoutsQuery());
            return Ok(result);
        }

        [HttpGet("{id}", Name = "GetWorkoutById")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _mediator.Send(new GetWorkoutQuery(id));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateWorkoutCommand workout)
        {
            var result = await _mediator.Send(workout);
            return Created(workout.workout_name, result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateWorkoutCommand workout)
        {
            workout.workout_id = id;
            var result = await _mediator.Send(workout);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteWorkoutCommand(id));
            return Ok(result);
        }
    }
}
