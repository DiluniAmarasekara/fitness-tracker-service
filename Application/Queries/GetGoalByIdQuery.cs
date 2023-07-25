using fitness_tracker_service.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_service.Application.Queries
{
    public class GetGoalByIdQuery : IRequest<GoalDto>
    {
        public long _goalId { get; set; }

        public GetGoalByIdQuery(long goalId)
        {
            _goalId = goalId;
        }
    }
}
