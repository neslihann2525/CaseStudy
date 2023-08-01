namespace CaseStudy.Business.AbstractUnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();
        Task RollbackAsync();
    }
}

