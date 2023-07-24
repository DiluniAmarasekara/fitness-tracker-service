using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class CreateCheatmealCommand : IRequest<string>
    {
        public long cheat_id { get; set; }

        public DateTime date_of_cheat { get; set; }

        public string meal { get; set; }

        public long workout_id { get; set; }

        public CreateCheatmealCommand(long cheatId, DateTime dateOfCheat, string calories, long workoutId)
        {
            this.cheat_id = cheatId;
            this.date_of_cheat = dateOfCheat;
            this.meal = calories;
            this.workout_id = workoutId;
        }

        public CreateCheatmealCommand(long cheatId)
        {
            cheat_id = cheatId;
        }

        public CreateCheatmealCommand()
        {
        }
    }
}
