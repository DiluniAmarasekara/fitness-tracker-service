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
    public class UpdateCheatmealCommandHandler : IRequestHandler<CreateUpdateDeleteCheatmealCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public UpdateCheatmealCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            Workout workout = _repository.Workout.FindByCondition(x => x.workout_id.Equals(request.workout_id)).FirstOrDefault();
            Cheatmeal cheatmeal = _repository.Cheatmeal.FindByCondition(x => x.cheat_id.Equals(request.cheat_id)).FirstOrDefault();
            if (workout != null)
            {
                if (cheatmeal != null)
                {
                    try
                    {
                        _repository.Cheatmeal.Update(_mapper.Map<Cheatmeal>(request));
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
