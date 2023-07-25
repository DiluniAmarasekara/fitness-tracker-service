using AutoMapper;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Domain.Repositories.Impl;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.Commands.Handlers
{
    public class LogTodayWeightCommandHandler : IRequestHandler<LogTodayWeightCommand, string>
    {
        private readonly IWeightRepository _weightRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly IMapper _mapper;

        public LogTodayWeightCommandHandler(IWeightRepository weightRepository, IGoalRepository goalRepository, IMapper mapper)
        {
            _weightRepository = weightRepository;
            _goalRepository = goalRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(LogTodayWeightCommand request, CancellationToken cancellationToken)
        {
            GoalTo goal = await _goalRepository.getById(request.goal_id);
            if (goal != null)
            {
                try
                {
                    WeightTo weight = new WeightTo(request.goal_id, DateTime.Now, request.weight);
                    bool status = await _weightRepository.add(_mapper.Map<Weight>(weight));

                    goal.bmi = bmiCalculation(goal.current_height, request.weight);
                    goal.current_weight = request.weight;
                    bool isUpdated = await _goalRepository.modify(_mapper.Map<Goal>(goal));

                    if (isUpdated && status)
                    {
                        return await Task.FromResult("Today's weight has been successfully logged!");
                    }
                    else return await Task.FromResult("Log today's weight has been failled!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Log today's weight has been failled! Goal is not exist!");
        }

        private double bmiCalculation(double current_height, double weight)
        {
            string[] parts = current_height.ToString().Split('.');
            int feet = int.Parse(parts[0]);
            int inches = int.Parse(parts[1]);
            int totalInches = feet * 12 + inches;
            double meters = totalInches * 0.0254;
            return weight / (meters * meters);

        }
    }
}
