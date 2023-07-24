using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateUpdateDeleteWorkoutCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CreateWorkoutCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            try {
                //diluni
                // _workoutRepository.save(_mapper.Map<WorkoutSchedule>(request));

                //  if (request.exercises.Count>0) {
                // List<DomWorkoutExercise> workoutExercises = new List<DomWorkoutExercise>();
                // request.exercises.ForEach(exercise =>
                //{
                // DomWorkoutExercise workoutExercise = new DomWorkoutExercise(exercise.exerciseId, request.workoutId);
                //  workoutExercises.Add(workoutExercise);
                // });
                //  _exerciseRepository.saveAll(workoutExercises);
                //}
                return await Task.FromResult("Workout has been successfully created!");
            }
            catch(Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
