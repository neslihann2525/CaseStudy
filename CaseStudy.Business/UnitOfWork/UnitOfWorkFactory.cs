using CaseStudy.Business.AbstractUnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace CaseStudy.Business.UnitOfWork
{
    public class UnitOfWorkFactory<TDbContext> : IUnitOfWorkFactory
         where TDbContext : DbContext
    {
        protected TDbContext DbContext { get; private set; }

        public UnitOfWorkFactory(
            TDbContext dbContext)
        {
            DbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IUnitOfWork> NewAsync()
        {
            var transaction = await DbContext.Database.BeginTransactionAsync();

            var unitOfWork = new UnitOfWork<TDbContext>(DbContext, transaction);

            return unitOfWork;
        }
    }
}

