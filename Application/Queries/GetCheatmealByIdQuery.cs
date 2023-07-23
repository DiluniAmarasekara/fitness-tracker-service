using fitness_tracker_service.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_service.Application.Queries
{
    public class GetCheatmealByIdQuery : IRequest<CheatmealDto>
    {
        public int _cheatmealId { get; set; }

        public GetCheatmealByIdQuery(int cheatmealId)
        {
            _cheatmealId = cheatmealId;
        }
    }
}
