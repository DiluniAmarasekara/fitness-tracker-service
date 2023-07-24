using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class DeleteteWorkoutCommandHandler : IRequestHandler<CreateUpdateDeleteWorkoutCommand, string>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public DeleteteWorkoutCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            Workout workout = _repository.Workout.FindByCondition(x => x.workout_id.Equals(request.workout_id)).FirstOrDefault();
            if (workout != null)
            {
                try
                {
                    //Diluni
                    _repository.Workout.Delete(workout);
                    return await Task.FromResult("Workout has been successfully deleted!");
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
