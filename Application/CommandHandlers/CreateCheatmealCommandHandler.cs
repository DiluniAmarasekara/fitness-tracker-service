using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class CreateCheatmealCommandHandler : IRequestHandler<CreateUpdateDeleteCheatmealCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CreateCheatmealCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            Workout workout = _repository.Workout.FindByCondition(x => x.workout_id.Equals(request.workout_id)).FirstOrDefault();
            if (workout != null)
            {
                try
                {
                    _repository.Cheatmeal.Create(_mapper.Map<Cheatmeal>(request));
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
