using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace fitness_tracker_service.WebApi
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
