using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using StockDataProvider.Extensions;
using StockDataProvider.Services;
using StockDataProvider.Worker;

using StrongInject.Extensions.DependencyInjection;

namespace StockDataProvider;

public static class ModuleExtensions
{
    public static IServiceCollection AddStockDataProviderModule(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingletonServiceUsingContainer<StockDataProviderContainer, SimpleWorker>();
        services.AddTransientServiceUsingContainer<StockDataProviderContainer, IStockDataProvider>();
        services.AddHostedService<SimpleWorker>();
        return services;
    }
}