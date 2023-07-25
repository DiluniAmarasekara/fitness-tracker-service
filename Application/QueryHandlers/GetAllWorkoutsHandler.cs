﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetAllWorkoutsHandler : IRequestHandler<GetAllWorkoutsQuery, List<WorkoutDto>>
    {
        private readonly IWorkoutRepository _repository;
        private readonly IMapper _mapper;


        public GetAllWorkoutsHandler(IWorkoutRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<WorkoutDto>> Handle(GetAllWorkoutsQuery request, CancellationToken cancellationToken)
        {
            List<WorkoutTo> workouts = await _repository.getAll();
            return _mapper.Map<List<WorkoutDto>>(workouts);
        }
    }
}
