using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class DeleteCheatmealCommand : IRequest<string>
    {
        public long cheat_id { get; set; }

        public DeleteCheatmealCommand(long cheatId)
        {
            cheat_id = cheatId;
        }

        public DeleteCheatmealCommand()
        {
        }
    }
}
