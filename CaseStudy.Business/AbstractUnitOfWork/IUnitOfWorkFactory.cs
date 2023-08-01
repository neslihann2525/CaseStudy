namespace CaseStudy.Business.AbstractUnitOfWork
{
    public interface IUnitOfWorkFactory
    {
        Task<IUnitOfWork> NewAsync();
    }

    public interface IUnitOfWorkFactory<TUserKey, TTenantEntityKey> : IUnitOfWorkFactory
    {
        Task<IUnitOfWork> NewAsync(TTenantEntityKey tenantId);
    }

    public interface IUnitOfWorkFactory_UserStructKey<TUserKey, TTenantEntityKey> :
        IUnitOfWorkFactory<TUserKey?, TTenantEntityKey>
        where TUserKey : struct
    {
    }

    public interface IUnitOfWorkFactory_TenantStructKey<TUserKey, TTenantEntityKey> :
        IUnitOfWorkFactory<TUserKey, TTenantEntityKey?>
        where TTenantEntityKey : struct
    {
    }

    public interface IUnitOfWorkFactory_StructKey<TUserKey, TTenantEntityKey> :
        IUnitOfWorkFactory<TUserKey?, TTenantEntityKey?>
        where TUserKey : struct
        where TTenantEntityKey : struct
    {
    }
}