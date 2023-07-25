using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace fitness_tracker_service.Controllers
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

        /// <summary>
        /// Retrieves a specific item by ID.
        /// </summary>
        /// <param name="reportType">The ID of the item.</param>
        /// <returns>The item with the given ID.</returns>
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
