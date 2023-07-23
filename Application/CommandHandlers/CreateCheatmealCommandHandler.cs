using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateCheatmealCommandHandler : IRequestHandler<CreateUpdateDeleteCheatmealCommand, string>
    {
        private readonly ICheatmealRepository _cheatmealRepository;
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;

        public CreateCheatmealCommandHandler(ICheatmealRepository cheatmealRepository, IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _cheatmealRepository = cheatmealRepository;
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            WorkoutSchedule workout = _workoutRepository.GetWorkoutById((int)request.workoutId).GetAwaiter().GetResult();
            if (workout != null)
            {
                try
                {
                    _cheatmealRepository.save(_mapper.Map<Cheatmeal>(request));
                    return await Task.FromResult("Cheatmeal has been successfully created!");
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
