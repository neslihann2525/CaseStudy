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
            await _context.SaveChangesAsync();
            return entity;
        }
        public async Task<List<TEntity>> CreateList(List<TEntity> entityList)
        {
            foreach (var entity in entityList)
            {
                await _context.Set<TEntity>().AddAsync(entity);
            }
            await _context.SaveChangesAsync();
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

        public async virtual Task<bool> Update(TEntity entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                return await _context.SaveChangesAsync() > 0 ? true : false;
            }
            catch (Exception ex)
            {
                //throw;
                //log
            }
            return false;
        }
        public async virtual Task<bool> Remove(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async virtual Task<bool> RemoveRange(List<TEntity> entity)
        {
            _context.Set<TEntity>().RemoveRange(entity);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async virtual Task<bool> RemoveAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            var deletedResult = await _context.Set<TEntity>().Where(filter).AsNoTracking().ToListAsync();
            _context.Set<TEntity>().RemoveRange(deletedResult);
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}
