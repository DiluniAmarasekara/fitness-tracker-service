using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateWorkoutCommandHandler : IRequestHandler<CreateWorkoutCommand, string>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public CreateWorkoutCommandHandler(IWorkoutRepository workoutRepository, IGoalRepository goalRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            GoalTo goal = await _goalRepository.getById(request.goal_id);
            if (goal != null)
            {
                try
                {
                    bool status = await _workoutRepository.add(_mapper.Map<Workout>(request));
                    if (status)
                        {
                            return await Task.FromResult("Workout has been successfully created! Now you can add exercises for this workout.");

                        }
                    else return await Task.FromResult("Create Workout has been failled!");
                    }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Create workout has been failled! Goal is not exist!");
        }
    }
}
