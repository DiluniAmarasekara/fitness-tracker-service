using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class GenerateReportCommand : IRequest<string>
    {
        public ReportType reportType { get; set; }
        public DateTime from_date { get; set; }
        public DateTime to_date { get; set; }

        public GenerateReportCommand(ReportType reportType, DateTime from_date, DateTime to_date)
        {
            this.reportType = reportType;
            this.from_date = from_date;
            this.to_date = to_date;
        }
    }
}
