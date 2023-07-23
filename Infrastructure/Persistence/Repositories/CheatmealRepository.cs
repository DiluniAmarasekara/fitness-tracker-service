﻿using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class CheatmealRepository : ICheatmealRepository
    {
        private readonly FitnessDbContext _dbContext;

        public CheatmealRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<List<Cheatmeal>> GetAllCheatmeals()
        {
            return _dbContext.findAllCheatmeals();
        }
        public Task<Cheatmeal> GetCheatmealById(int cheatmealId)
        {
            return _dbContext.findCheatmealById(cheatmealId);
        }
    }
}