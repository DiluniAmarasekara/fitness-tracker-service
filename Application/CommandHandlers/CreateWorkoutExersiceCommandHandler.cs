using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateWorkoutExersiceCommandHandler : IRequestHandler<CreateWorkoutExerciseCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CreateWorkoutExersiceCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            Workout workout = _repository.Workout.FindByCondition(x => x.workout_id.Equals(request.workout_id)).FirstOrDefault();
            if (workout != null)
            {
                try
                {
                    if (request.exercises.Count > 0)
                    {
                        request.exercises.ForEach(exercise =>
                    {
                        WorkoutExercise workoutExercise = new WorkoutExercise(exercise.exercise_id, request.workout_id);
                        _repository.WorkoutExercise.Create(workoutExercise);
                    });
                        return await Task.FromResult("Workout exercises have been successfully added!");
                    }
                    else return await Task.FromResult("Please input exercises!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Add workout exercises has been failled! Workout is not exist!");
        }
    }
}
