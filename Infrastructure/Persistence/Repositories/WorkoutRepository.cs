using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class WorkoutRepository : IWorkoutRepository
    {
        private readonly FitnessDbContext _dbContext;

        public WorkoutRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<WorkoutSchedule> GetWorkoutById(int workoutId)
        {
            return _dbContext.findWorkoutById(workoutId);
        }

        Task<List<WorkoutSchedule>> IWorkoutRepository.GetAllWorkouts()
        {
            return _dbContext.findAllWorkouts();
        }
    }
}
