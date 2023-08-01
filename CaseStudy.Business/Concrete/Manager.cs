using CaseStudy.Business.Abstract;
using CaseStudy.Business.Result;
using CaseStudy.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CaseStudy.Business.Concrete
{
    public class Manager<TEntity> : IManager<TEntity> where TEntity : class, new()
    {
        private readonly IRepository<TEntity> _repository;
        public Manager(IRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public Task<IDataResult<TEntity>> Create(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveAllByFilter(Expression<Func<TEntity, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public Task<IResult> RemoveRange(List<TEntity> entity)
        {
            throw new NotImplementedException();
        }
    }
}
