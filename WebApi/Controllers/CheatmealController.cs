using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_service.WebApi.Controllers
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

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCheatmealCommand cheatmeal)
        {
            var result = await _mediator.Send(cheatmeal);
            return Created(cheatmeal.date_of_cheat.ToString(), result);
        }

        [HttpPut]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateCheatmealCommand cheatmeal)
        {
            cheatmeal.cheat_id = id;
            var result = await _mediator.Send(cheatmeal);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteCheatmealCommand(id));
            return Ok(result);
        }
    }
}
