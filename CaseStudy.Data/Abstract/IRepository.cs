using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Data.Abstract
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<List<TEntity>> CreateList(List<TEntity> entityList);
        Task<List<TEntity>> GetAll();
        Task<TEntity> GetFirstByFilter(Expression<Func<TEntity, bool>> filter);
        Task<List<TEntity>> GetAllByFilter(Expression<Func<TEntity, bool>> filter);
        Task<bool> Update(TEntity entity);
        Task<bool> Remove(TEntity entity);
        Task<bool> RemoveRange(List<TEntity> entity);
        Task<bool> RemoveAllByFilter(Expression<Func<TEntity, bool>> filter);
    }
}
