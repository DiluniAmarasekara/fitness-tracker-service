using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateUpdateDeleteWorkoutCommand, string>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            try {
                _workoutRepository.save(_mapper.Map<WorkoutSchedule>(request));

                if (request.exercises.Count>0) {
                    List<WorkoutExercise> workoutExercises = new List<WorkoutExercise>();
                    request.exercises.ForEach(exercise =>
                    {
                        WorkoutExercise workoutExercise= new WorkoutExercise(exercise.exerciseId, request.workoutId);
                        workoutExercises.Add(workoutExercise);
                    });
                    _exerciseRepository.saveAll(workoutExercises);
                }
                return await Task.FromResult("Workout has been successfully created!");
            }
            catch(Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
