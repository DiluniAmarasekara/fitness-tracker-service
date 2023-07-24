using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetWorkoutByIdHandler : IRequestHandler<GetWorkoutQuery, WorkoutDto>
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public GetWorkoutByIdHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WorkoutDto> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
        {
            Workout workout = _repository.Workout.FindByCondition(x => x.workout_id.Equals(request._workoutId)).FirstOrDefault();
            return _mapper.Map<WorkoutDto>(workout);
        }
    }
}
