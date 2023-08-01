using CaseStudy.Business.AbstractUnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CaseStudy.Business.UnitOfWork
{
    public class UnitOfWork<TDbContext> : IUnitOfWork
         where TDbContext : DbContext
    {
        private TDbContext _dbContext;
        private IDbContextTransaction _dbContextTransaction;

        public UnitOfWork(
            TDbContext dbContext,
            IDbContextTransaction dbContextTransaction)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _dbContextTransaction = dbContextTransaction ?? throw new ArgumentNullException(nameof(dbContextTransaction));
        }

        public async Task CommitAsync()
        {
            // TODO: Only call this if it hasn't been called already
            await _dbContext.SaveChangesAsync();

            await _dbContextTransaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _dbContextTransaction.RollbackAsync();
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContextTransaction.Dispose();
                }

                _dbContext = null;
                _dbContextTransaction = null;

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }
        #endregion
    }
}
