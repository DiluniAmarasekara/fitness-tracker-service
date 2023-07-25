using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class UpdateWorkoutCommandHandler : IRequestHandler<UpdateWorkoutCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UpdateWorkoutCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
             Workout workout = _repository.Workout.FindByCondition(x=>x.workout_id.Equals(request.workout_id)).FirstOrDefault();
             if (workout != null)
             {
            try
            {
                    if (request.exercises.Count > 0)
                    {
                        List<WorkoutExercise> workoutExercises = _repository.WorkoutExercise.FindByCondition(x => x.workout_id.Equals(request.workout_id)).ToList();
                        workoutExercises.ForEach(exsistExercise =>
                        {
                            _repository.WorkoutExercise.Delete(exsistExercise);
                        });

                        request.exercises.ForEach(exercise =>
                        {
                            WorkoutExercise workoutExercise = new WorkoutExercise(exercise.exercise_id, request.workout_id);
                            _repository.WorkoutExercise.Create(workoutExercise);
                        });
                    }
                    _repository.Workout.Update(_mapper.Map<Workout>(request));
                    return await Task.FromResult("Workout has been successfully updated!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
           else return await Task.FromResult("Update workout has been failled! Workout is not exist!");
        }
    }
}
