using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class CreateWorkoutCommand : IRequest<string>
    {
        public long workout_id { get; set; }

        public string workout_name { get; set; }

        public DateTime from_date { get; set; }

        public DateTime to_date { get; set; }

        public long goal_id { get; set; }

        public CreateWorkoutCommand(long workoutId, string workoutName, DateTime fromDate, DateTime toDate, long goalId)
        {
            this.workout_id = workoutId;
            this.workout_name = workoutName;
            this.from_date = fromDate;
            this.to_date = toDate;
            this.goal_id = goalId;
        }

        public CreateWorkoutCommand(long workoutId)
        {
            workout_id = workoutId;
        }

        public CreateWorkoutCommand()
        {
        }
    }
}
