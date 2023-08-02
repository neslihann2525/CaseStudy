using CaseStudy.Data.Abstract;
using CaseStudy.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Concrete
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, new()
    {
        private readonly CaseStudyContext _context;
        public Repository(CaseStudyContext context)
        {
            _context = context;
        }
        public async virtual Task<TEntity> Create(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
            return entity;
        }
        public async Task<List<TEntity>> CreateList(List<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            return entityList;
        }
        public async virtual Task<List<TEntity>> GetAll()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }
        public async virtual Task<TEntity> GetFirstByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var entity = await _context.Set<TEntity>().Where(filter).AsNoTracking().FirstOrDefaultAsync();
            if (entity != null)
                _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public async Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
        }

        public virtual void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public virtual void RemoveRange(List<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
        }

        public async virtual Task RemoveAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var deletedResult = await _context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
            _context.Set<TEntity>().RemoveRange(deletedResult);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
