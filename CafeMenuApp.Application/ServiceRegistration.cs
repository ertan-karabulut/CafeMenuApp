using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CafeMenuApp.Application;

public static class ServiceRegistration
{
    public static void AddApplicationLayer(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAutoMapper(Assembly.GetExecutingAssembly());
        //serviceCollection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
