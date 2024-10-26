using CafeMenuApp.Application.Interface.Persistence.Repository;
using CafeMenuApp.Application.Interface.Persistence.UoW;
using CafeMenuApp.Persistence.Context;
using CafeMenuApp.Persistence.Repository;
using CafeMenuApp.Persistence.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CafeMenuApp.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceLayer(this IServiceCollection serviceCollection, IConfiguration configuration)
    {
        serviceCollection.AddDbContext<CafeMenuDbContext>(opt =>
    opt.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        serviceCollection.AddScoped<ICategoryRepository, CategoryRepository>();
        serviceCollection.AddScoped<IProductRepository, ProductRepository>();
        serviceCollection.AddScoped<IPropertyRepository, PropertyRepository>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUnitOfWork, UnitOfWork>();
    }
}
