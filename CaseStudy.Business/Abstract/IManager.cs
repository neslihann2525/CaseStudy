using CaseStudy.Business.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Abstract
{
    public interface IManager<TEntity>
    {
        Task<IDataResult<TEntity>> Create(TEntity entity);
        Task<IResult> Remove(TEntity entity);
        Task<IResult> RemoveRange(List<TEntity> entity);
        Task<IResult> RemoveAllByFilter(Expression<Func<TEntity, bool>> filter);
    }
}
