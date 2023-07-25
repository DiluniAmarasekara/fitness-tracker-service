using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_service.WebApi
{
    [Route("api/Exercise")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {
        private readonly ILogger<ExerciseController> _logger;
        private readonly IMediator _mediator;

        public ExerciseController(ILogger<ExerciseController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllExercise")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllExerciseQuery());
            return Ok(result);
        }

        [HttpGet("{workoutId}", Name = "GetExerciseByWorkoutId")]
        public async Task<IActionResult> Get(int workoutId)
        {
            var result = await _mediator.Send(new GetExercisesByWorkoutIdQuery(workoutId));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost("{workoutId}", Name = "AddExercisesForWorkout")]
        public async Task<IActionResult> Post([FromBody] CreateWorkoutExerciseCommand workoutExercise)
        {
            var result = await _mediator.Send(workoutExercise);
            return Ok(result);
        }

    }
}
