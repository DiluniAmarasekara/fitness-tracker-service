﻿using fitness_tracker_service.Application.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_service.Application.Queries
{
    public class GetGoalByIdQuery : IRequest<GoalDto>
    {
        public int _goalId { get; set; }

        public GetGoalByIdQuery(int goalId)
        {
            _goalId = goalId;
        }
    }
}
