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
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper _mapper;

        public DeleteteCheatmealCommandHandler(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<string> Handle(DeleteCheatmealCommand request, CancellationToken cancellationToken)
        {
            Cheatmeal cheatmeal = _repository.Cheatmeal.FindByCondition(x => x.cheat_id.Equals(request.cheat_id)).FirstOrDefault();
            if (cheatmeal != null)
            {
                try
                {
                    _repository.Cheatmeal.Delete(cheatmeal);
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
