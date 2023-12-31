﻿using System.Linq.Expressions;
using fitness_tracker_service.Domain.Repositories;
using fitness_tracker_service.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace fitness_tracker_service.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected RepositoryContext RepositoryContext { get; set; }
        public RepositoryBase(RepositoryContext repositoryContext)
        {
            RepositoryContext = repositoryContext;
        }
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) =>
            RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
            RepositoryContext.SaveChanges();
        }
        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
            RepositoryContext.SaveChanges();
        }
        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
            RepositoryContext.SaveChanges();
        }
    }
}
