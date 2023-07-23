using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class DeleteteWorkoutCommandHandler : IRequestHandler<CreateUpdateDeleteWorkoutCommand, string>
    {
        private readonly IWorkoutRepository _workoutRepository;
        private readonly IExerciseRepository _exerciseRepository;
        private readonly IMapper _mapper;

        public DeleteteWorkoutCommandHandler(IWorkoutRepository workoutRepository, IExerciseRepository exerciseRepository, IMapper mapper)
        {
            _workoutRepository = workoutRepository;
            _exerciseRepository = exerciseRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteWorkoutCommand request, CancellationToken cancellationToken)
        {
            WorkoutSchedule workout = _workoutRepository.GetWorkoutById((int)request.workoutId).GetAwaiter().GetResult();
            if (workout != null)
            {
                try
                {
                    _workoutRepository.delete(request.workoutId);
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
