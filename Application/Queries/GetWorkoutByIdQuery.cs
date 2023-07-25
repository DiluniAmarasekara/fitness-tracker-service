using fitness_tracker_service.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_service.Application.Queries
{
    public class GetWorkoutQuery : IRequest<WorkoutDto>
    {
        public long _workoutId { get; set; }

        public GetWorkoutQuery(long workoutId)
        {
            _workoutId = workoutId;
        }
    }
}
