﻿using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace fitness_tracker_service.Application.Queries
{
    public class GetAllExerciseQuery : IRequest<List<ExerciseDto>>
    {
    }
}
