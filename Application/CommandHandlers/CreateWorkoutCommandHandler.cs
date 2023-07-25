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
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public CreateWorkoutCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateWorkoutCommand request, CancellationToken cancellationToken)
        {
            try {
                _repository.Workout.Create(_mapper.Map<Workout>(request));
                return await Task.FromResult("Workout has been successfully created! Now you can add exercises for this workout.");
            }
            catch(Exception ex)
            {
                return await Task.FromResult(ex.Message);
            }
        }
    }
}
