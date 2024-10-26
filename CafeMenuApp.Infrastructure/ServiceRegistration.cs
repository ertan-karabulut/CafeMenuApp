using CafeMenuApp.Application.Interface.Infrastructure.Service;
using CafeMenuApp.Infrastructure.Service;
using CafeMenuApp.Infrastructure.Validator;
using Microsoft.Extensions.DependencyInjection;

namespace CafeMenuApp.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ICategoryValidator, CategoryValidator>();
        serviceCollection.AddScoped<IProductValidator, ProductValidator>();
        serviceCollection.AddScoped<IUserValidator, UserValidator>();
        serviceCollection.AddScoped<ICategoryService, CategoryService>();
        serviceCollection.AddScoped<IProductService, ProductService>();
        serviceCollection.AddScoped<IPropertyService, PropertyService>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IExchangeRateService, ExchangeRateService>();
    }
}
