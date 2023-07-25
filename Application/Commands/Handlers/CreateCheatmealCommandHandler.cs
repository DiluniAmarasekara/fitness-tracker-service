using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateCheatmealCommandHandler : IRequestHandler<CreateCheatmealCommand, string>
    {
        private readonly ICheatmealRepository _cheatRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public CreateCheatmealCommandHandler(ICheatmealRepository cheatRepository, IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _cheatRepository = cheatRepository;
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateCheatmealCommand request, CancellationToken cancellationToken)
        {
            WorkoutTo workout = await _workoutRepository.getById(request.workout_id);
            if (workout != null)
            {
                try
                {
                    bool status = await _cheatRepository.add(_mapper.Map<Cheatmeal>(request));
                    if (status)
                    {
                        return await Task.FromResult("Cheatmeal has been successfully created!");
                    }
                    else return await Task.FromResult("Create cheatmeal has been failled!"); 
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Create cheatmeal has been failled! Workout is not exist!");
        }
    }
}
