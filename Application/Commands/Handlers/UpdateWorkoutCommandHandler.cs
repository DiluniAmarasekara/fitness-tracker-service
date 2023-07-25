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
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly IWorkoutExerciseRepository _workExRepository;
        private readonly IMapper _mapper;

        public UpdateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IGoalRepository goalRepository, IWorkoutExerciseRepository workExRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _goalRepository = goalRepository;
            _workExRepository = workExRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(UpdateWorkoutCommand request, CancellationToken cancellationToken)
        {
            WorkoutTo workout = await _workoutRepository.getById(request.workout_id);
            if (workout != null)
             {
                GoalTo goal = await _goalRepository.getById(request.goal_id);
                if (goal != null)
                {
                    try
                    {
                        if (request.exercises.Count > 0)
                        {
                            List<WorkoutExerciseTo> workoutExercises = await _workExRepository.getAllByWorkoutId(request.workout_id);
                            if (workoutExercises.Count > 0)
                            {
                                bool isDelete = await _workExRepository.deleteAllByWorkoutId(_mapper.Map<List<WorkoutExercise>>(workoutExercises));
                                if(!isDelete) return await Task.FromResult("Exception occurred while deleting old workout exercises!");
                            }
                            bool isAdded = await _workExRepository.addAll(request.workout_id, _mapper.Map<List<Exercise>>(request.exercises));
                            if (!isAdded) return await Task.FromResult("Exception occurred while adding new workout exercises!");
                        }
                        bool status = await _workoutRepository.modify(_mapper.Map<Workout>(request));
                        if (status) return await Task.FromResult("Workout has been successfully updated!");
                        else return await Task.FromResult("Update workout has been failled!");
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(ex.Message);
                    }
                }
                else return await Task.FromResult("Update workout has been failled! Goal is not exist!");
            }
           else return await Task.FromResult("Update workout has been failled! Workout is not exist!");
        }
    }
}
