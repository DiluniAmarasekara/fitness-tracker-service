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
        public int _workoutId { get; set; }

        public GetWorkoutQuery(int workoutId)
        {
            _workoutId = workoutId;
        }
    }
}
