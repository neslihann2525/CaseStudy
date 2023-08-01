using CaseStudy.Business.Abstract;
using CaseStudy.Business.AbstractUnitOfWork;
using CaseStudy.Business.Concrete;
using CaseStudy.Business.UnitOfWork;
using CaseStudy.Data.Abstract;
using CaseStudy.Data.Concrete;
using CaseStudy.Data.Context;
using CaseStudy.Entities.Models;
using Microsoft.Extensions.DependencyInjection;

namespace CaseStudy.Business.Factories
{
    public static class DifferentImplementationsFactoryExtension
    {
        public static void AddDependenciesFactory(this IServiceCollection services)
        {
            services.AddAbstractFactory<IUserRepository, UserRepository>();
            services.AddAbstractFactory<IUsersManager, UsersManager>();

            services.AddAbstractFactory<ICartRepository, CartRepository>();
            services.AddAbstractFactory<ICartManager, CartManager>();

            services.AddAbstractFactory<IProductRepository, ProductRepository>();
            services.AddAbstractFactory<IProductManager, ProductManager>();

            services.AddAbstractFactory<IPaymentManager, PaymentManager>();

            services.AddAbstractFactory<IOrderRepository, OrderRepository>();
            services.AddAbstractFactory<IOrderManager, OrderManager>();

            services.AddScoped<IUnitOfWorkFactory, UnitOfWorkFactory<CaseStudyContext>>();

            services.AddTransient<IRepository<Cart>,CartRepository>();
            services.AddTransient<IRepository<Order>, OrderRepository>();
            services.AddTransient<IRepository<Product>, ProductRepository>();
            services.AddScoped<Func<IEnumerable<IRepository<Cart>>>>(x => () => x.GetService<IEnumerable<IRepository<Cart>>>()!);
            services.AddScoped<Func<IEnumerable<IRepository<Order>>>>(x => () => x.GetService<IEnumerable<IRepository<Order>>>()!);
            services.AddScoped<Func<IEnumerable<IRepository<Product>>>>(x => () => x.GetService<IEnumerable<IRepository<Product>>>()!);
            //services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IRepositoryFactory<>), typeof(RepositoryFactory<>));


            services.AddTransient<EmailService>();
        }

        public interface IRepositoryFactory<TEntity> 
        {
            IRepository<TEntity> Create();
        }

        public class RepositoryFactory<TEntity> : IRepositoryFactory<TEntity> where TEntity : class 
        {
            private readonly Func<IEnumerable<IRepository<TEntity>>> _factory;
            public RepositoryFactory(Func<IEnumerable<IRepository<TEntity>>> factory)
            {
                _factory = factory;
            }

            public IRepository<TEntity> Create()
            {
                var set = _factory();
                IRepository<TEntity> output = set.First();
                return output;
            }
        }
    }
}
