using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class CreateUpdateDeleteWorkoutCommand : IRequest<string>
    {
        public long workoutId { get; set; }
        public string workoutName { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public long goalId { get; set; }

        public List<ExerciseDto> exercises { get; set; }
        
        public CreateUpdateDeleteWorkoutCommand(long workoutId, string workoutName, DateTime fromDate, DateTime toDate, long goalId, List<ExerciseDto> exercises)
        {
            this.workoutId = workoutId;
            this.workoutName = workoutName;
            this.fromDate = fromDate;
            this.toDate = toDate;
            this.goalId = goalId;
            this.exercises = exercises;
        }

        public CreateUpdateDeleteWorkoutCommand(long workoutId)
        {
            workoutId = workoutId;
        }
    }
}
