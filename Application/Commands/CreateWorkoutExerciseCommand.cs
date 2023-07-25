using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class CreateWorkoutExerciseCommand : IRequest<string>
    {
        public long workout_id { get; set; }
        public List<ExerciseDto> exercises { get; set; }
        public CreateWorkoutExerciseCommand() { }
        public CreateWorkoutExerciseCommand(long workoutId)
        {
            workout_id = workoutId;
        }
    }
}
