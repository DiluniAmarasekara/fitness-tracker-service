using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class UpdateCheatmealCommandHandler : IRequestHandler<CreateUpdateDeleteCheatmealCommand, string>
    {
        private readonly ICheatmealRepository _cheatmealRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public UpdateCheatmealCommandHandler(ICheatmealRepository cheatmealRepository, IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _cheatmealRepository = cheatmealRepository;
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            WorkoutSchedule workout = _workoutRepository.GetWorkoutById((int)request.workoutId).GetAwaiter().GetResult();
            Cheatmeal cheatmeal = _cheatmealRepository.GetCheatmealById((int)request.cheatId).GetAwaiter().GetResult();
            if (workout != null)
            {
                if (cheatmeal != null)
                {
                    try
                    {
                        _cheatmealRepository.update(_mapper.Map<Cheatmeal>(request));
                        return await Task.FromResult("Cheatmeal has been successfully updated!");
                    }
                    catch (Exception ex)
                    {
                        return await Task.FromResult(ex.Message);
                    }
                }
                else return await Task.FromResult("Update cheatmeal has been failled! Cheatmeal is not exist!");
            }
            else return await Task.FromResult("Update cheatmeal has been failled! Workout is not exist!");
        }
    }
}
