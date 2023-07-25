using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace fitness_tracker_service.WebApi.Controllers
{
    [Route("api/Report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly ILogger<ReportController> _logger;
        private readonly IMediator _mediator;

        public ReportController(ILogger<ReportController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Report generation", Description = "0-Workout report, 1-Cheat meal report, 2-Weight report, 3-Exercise report (FromDate, ToDate are not needed.)")]
        [SwaggerResponse(200, "Successfully retrieved the item.")]
        [SwaggerResponse(404, "Item not found.")]
        public async Task<IActionResult> Post(ReportType reportType, DateTime fromDate, DateTime toDate)
        {
            var result = await _mediator.Send(new GenerateReportCommand(reportType, fromDate, toDate));
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

    }
}
