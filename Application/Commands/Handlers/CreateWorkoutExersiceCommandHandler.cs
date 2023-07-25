using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using fitness_tracker_service.Infrastructure.Persistence.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateWorkoutExersiceCommandHandler : IRequestHandler<CreateWorkoutExerciseCommand, string>
    {
        private readonly IWorkoutExerciseRepository _workoutExerciseRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutExersiceCommandHandler(IWorkoutExerciseRepository workoutExerciseRepository, IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutExerciseRepository = workoutExerciseRepository;
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateWorkoutExerciseCommand request, CancellationToken cancellationToken)
        {
            WorkoutTo workout = await _workoutRepository.getById(request.workout_id);
            if (workout != null)
            {
                List<WorkoutExerciseTo> workoutExercises = await _workoutExerciseRepository.getAllByWorkoutId(request.workout_id);
                if (workoutExercises.Count > 0)
                {
                    return await Task.FromResult("You already added exercises to the workout. For update exersices, please perform update workout function!");
                }
                else { 
                    try
                    {
                        if (request.exercises.Count > 0)
                        {
                            bool status = await _workoutExerciseRepository.addAll(request.workout_id, _mapper.Map<List<Exercise>>(request.exercises));
                            if (status)
                            { 
                                return await Task.FromResult("Workout exercises have been successfully added!"); 
                            }
                            else return await Task.FromResult("Add workout exercises has been failled!"); 
                        }
                        else return await Task.FromResult("Please input exercises!");
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(ex.Message);
                    }
                }
            }
            else return await Task.FromResult("Add workout exercises has been failled! Workout is not exist!");
        }
    }
}
