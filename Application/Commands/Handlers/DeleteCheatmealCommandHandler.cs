using AutoMapper;
using Azure;
using fitness_tracker_service.Application.Commands;
using fitness_tracker_service.Application.Dtos;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Entities;
using MediatR;

namespace fitness_tracker_service.Application.CommandHandlers
{
    public class DeleteteCheatmealCommandHandler : IRequestHandler<DeleteCheatmealCommand, string>
    {
        private readonly ICheatmealRepository _repository;
        private readonly IMapper _mapper;

        public DeleteteCheatmealCommandHandler(ICheatmealRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            CheatmealTo cheatmeal = await _repository.getById(request.cheat_id);
                if (cheatmeal != null)
            {
                try
                {
                    bool status = await _repository.delete(_mapper.Map<Cheatmeal>(cheatmeal));
                    if (status)
                    {
                        return await Task.FromResult("Cheatmeal has been successfully deleted!");
                    }
                    else return await Task.FromResult("Delete cheatmeal has been failled!");
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
