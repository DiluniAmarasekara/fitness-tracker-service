using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class UpdateWorkoutCommandHandler : IRequestHandler<CreateUpdateDeleteWorkoutCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UpdateWorkoutCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            // Diluni
            //  WorkoutSchedule workout = _workoutRepository.GetWorkoutById((int)request.workoutId).GetAwaiter().GetResult();
            //    if (workout != null)
            // {
            try
            {
                //       _workoutRepository.update(_mapper.Map<WorkoutSchedule>(request));

                //         if (request.exercises.Count > 0)
                // {
                // List<DomWorkoutExercise> workoutExercises = new List<DomWorkoutExercise>();
                //  request.exercises.ForEach(exercise =>
                //  {
                // DomWorkoutExercise workoutExercise = new DomWorkoutExercise(exercise.exerciseId, request.workoutId);
                // workoutExercises.Add(workoutExercise);
                // });
                // _exerciseRepository.updateAll(workout.workoutId, workoutExercises);
                // }
                return await Task.FromResult("Workout has been successfully updated!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            // }
            // else return await Task.FromResult("Update workout has been failled! Workout is not exist!");
        }
    }
}
