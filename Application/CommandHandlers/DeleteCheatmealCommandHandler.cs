using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class DeleteteCheatmealCommandHandler : IRequestHandler<CreateUpdateDeleteCheatmealCommand, string>
    {
        private readonly ICheatmealRepository _cheatmealRepository;
        private readonly IMapper _mapper;

        public DeleteteCheatmealCommandHandler(ICheatmealRepository cheatmealRepository, IMapper mapper)
        {
            _cheatmealRepository = cheatmealRepository;
            _mapper = mapper;
        }

        public async Task<string> Handle(CreateUpdateDeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            Cheatmeal cheatmeal = _cheatmealRepository.GetCheatmealById((int)request.cheatId).GetAwaiter().GetResult();
            if (cheatmeal != null)
            {
                try
                {
                    _cheatmealRepository.delete(request.cheatId);
                    return await Task.FromResult("Cheatmeal has been successfully deleted!");
                }
                catch (Exception ex)
                {
                    return await Task.FromResult(ex.Message);
                }
            }
            else return await Task.FromResult("Delete cheatmeal has been failled! Cheatmeal is not exist!");
        }
    }
}
