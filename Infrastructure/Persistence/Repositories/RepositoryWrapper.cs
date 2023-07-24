using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.DatabaseHandlers;

namespace fitness_tracker_service.Infrastructure.Persistence.Repositories
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private RepositoryContext _repoContext;
        private IWorkoutRepository _workout;
        private IGoalRepository _goal;
        private ICheatmealRepository _cheatmeal;
        private IExerciseRepository _exercise;
        public IWorkoutRepository Workout
        {
            get
            {
                if (_workout == null)
                {
                    _workout = new WorkoutRepository(_repoContext);
                }
                return _workout;
            }
        }

        public IGoalRepository Goal
        {
            get
            {
                if (_goal == null)
                {
                    _goal = new GoalRepository(_repoContext);
                }
                return _goal;
            }
        }

        public ICheatmealRepository Cheatmeal
        {
            get
            {
                if (_cheatmeal == null)
                {
                    _cheatmeal = new CheatmealRepository(_repoContext);
                }
                return _cheatmeal;
            }
        }

        public IExerciseRepository Exercise
        {
            get
            {
                if (_exercise == null)
                {
                    _exercise = new ExerciseRepository(_repoContext);
                }
                return _exercise;
            }
        }

        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        public void Save()
        {
            _repoContext.SaveChanges();
        }
    }
}
