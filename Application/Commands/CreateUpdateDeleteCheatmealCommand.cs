using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class CreateUpdateDeleteCheatmealCommand : IRequest<string>
    {
        public long cheatId { get; set; }
        public DateTime dateOfCheat { get; set; }
        public string calories { get; set; }
        public long workoutId { get; set; }

        public CreateUpdateDeleteCheatmealCommand(long cheatId, DateTime dateOfCheat, string calories, long workoutId)
        {
            this.cheatId = cheatId;
            this.dateOfCheat = dateOfCheat;
            this.calories = calories;
            this.workoutId = workoutId;
        }

        public CreateUpdateDeleteCheatmealCommand(long cheatId)
        {
            cheatId = cheatId;
        }
    }
}
