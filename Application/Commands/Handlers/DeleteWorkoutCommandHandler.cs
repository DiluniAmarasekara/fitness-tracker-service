using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using fitness_tracker_service.Infrastructure.Persistence.Repositories;
using MediatR;
using System.Collections.Generic;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class DeleteteWorkoutCommandHandler : IRequestHandler<DeleteWorkoutCommand, string>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly ICheatmealRepository _cheatRepository;
        private readonly IWorkoutExerciseRepository _workExRepository;
        private readonly IMapper _mapper;

        public DeleteteWorkoutCommandHandler(IWorkoutRepository workoutRepository, ICheatmealRepository cheatRepository, IWorkoutExerciseRepository workExRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _cheatRepository = cheatRepository;
            _workExRepository = workExRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            WorkoutTo workout = await _workoutRepository.getById(request.workout_id);
            if (workout != null)
            {
                try
                {
                    List<WorkoutExerciseTo> workoutExercises = await _workExRepository.getAllByWorkoutId(request.workout_id);
                    if (workoutExercises.Count>0) {
                        bool isDelete = await _workExRepository.deleteAllByWorkoutId(_mapper.Map<List<WorkoutExercise>>(workoutExercises));
                        if (!isDelete) return await Task.FromResult("Exception occurred while deleting workout exercises!");
                    }

                    List<CheatmealTo> cheatmeals = await _cheatRepository.getAllByWorkoutId(request.workout_id);
                    if (cheatmeals.Count > 0) {
                        bool isDelete = await _cheatRepository.deleteAllByWorkoutId(_mapper.Map<List<Cheatmeal>>(cheatmeals));
                        if (!isDelete) return await Task.FromResult("Exception occurred while deleting cheatmeals!");
                    }
                    bool status = await _workoutRepository.delete(_mapper.Map<Workout>(workout));
                    if (status) return await Task.FromResult("Workout has been successfully deleted!");
                    else return await Task.FromResult("Delete workout has been failled!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Delete workout has been failled! Workout is not exist!");
        }
    }
}
