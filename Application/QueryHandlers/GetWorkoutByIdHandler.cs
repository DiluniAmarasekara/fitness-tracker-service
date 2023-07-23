using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Application.Queries;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.QueryHandlers
{
    public class GetWorkoutByIdHandler : IRequestHandler<GetWorkoutQuery, WorkoutDto>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IMapper _mapper;


        public GetWorkoutByIdHandler(IWorkoutRepository workoutRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _mapper = mapper;
        }

        public async Task<WorkoutDto> Handle(GetWorkoutQuery request, CancellationToken cancellationToken)
        {
            WorkoutSchedule workout = await _workoutRepository.GetWorkoutById(request._workoutId);
            return _mapper.Map<WorkoutDto>(workout);
        }
    }
}
