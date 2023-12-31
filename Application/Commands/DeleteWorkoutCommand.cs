﻿using fitness_tracker_service.Application.Dtos;
using MediatR;

namespace fitness_tracker_service.Application.Commands
{
    public class DeleteWorkoutCommand : IRequest<string>
    {
        public long workout_id { get; set; }

        public DeleteWorkoutCommand(long workoutId)
        {
            workout_id = workoutId;
        }

        public DeleteWorkoutCommand()
        {
        }
    }
}
