using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class LogTodayWeightCommand : IRequest<string>
    {
        public long goal_id { get; set; }
        public double weight { get; set; }
        public LogTodayWeightCommand(long goal_id, double weight)
        {
            this.goal_id=goal_id;
            this.weight = weight;
        }
        public LogTodayWeightCommand()
        {
            
        }
    }
}
