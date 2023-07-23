using fitness_tracker_service.Domain.Models;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class ExerciseRepository : IExerciseRepository
    {
        private readonly FitnessDbContext _dbContext;

        public ExerciseRepository(FitnessDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<List<Exercise>> GetAllExercise()
        {
            return _dbContext.findAllExercise();
        }

        public Task<List<Exercise>> GetAllExerciseByWorkoutId(int workoutId)
        {
            return _dbContext.findAllExerciseByWorkoutId(workoutId);
        }

        public void saveAll(List<WorkoutExercise> workoutExercises)
        {
           _dbContext.saveAll(workoutExercises);
        }

        public void updateAll(long workoutId, List<WorkoutExercise> workoutExercises)
        {
            _dbContext.updateAll(workoutId, workoutExercises);
        }
    }
}
