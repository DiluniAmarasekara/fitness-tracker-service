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
    public class GetExercisesByWorkoutIdHandler : IRequestHandler<GetExercisesByWorkoutIdQuery, List<ExerciseDto>>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GetExercisesByWorkoutIdHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<ExerciseDto>> Handle(GetExercisesByWorkoutIdQuery request, CancellationToken cancellationToken)
        {
            List<ExerciseDto> responses = new List<ExerciseDto>();
            List<WorkoutExercise> workoutExercises = _repository.WorkoutExercise.FindByCondition(x => x.workout_id.Equals(request._workoutId)).ToList();
            workoutExercises.ForEach(exercise =>
            {
                Exercise exerciseDetail = _repository.Exercise.FindByCondition(x=>x.exercise_id.Equals(exercise.exercise_id)).FirstOrDefault();
                var response = _mapper.Map<ExerciseDto>(exerciseDetail);
                responses.Add(response);
            });
            return responses;
        }
    }
}
