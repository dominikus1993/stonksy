using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace StockDataProvider;

public static class ModuleExtensions
{
    public static IServiceCollection AddStockDataProviderModule(this IServiceCollection services)
    {
        return services;
    }
}