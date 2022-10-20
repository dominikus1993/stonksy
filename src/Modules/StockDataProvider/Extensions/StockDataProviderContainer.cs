using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

using StockDataProvider.Services;
using StockDataProvider.Worker;

using StrongInject;

namespace StockDataProvider.Extensions;

[Register(typeof(YahooFinanceStockDataProvider), Scope.InstancePerDependency, typeof(IStockDataProvider))]
[Register(typeof(SimpleWorker), Scope.SingleInstance)]
internal partial class StockDataProviderContainer : IContainer<SimpleWorker>, IContainer<IStockDataProvider>
{
    private readonly IServiceProvider _serviceProvider;

    public StockDataProviderContainer(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [Factory] private ILogger<T> GetLogger<T>() => _serviceProvider.GetRequiredService<ILogger<T>>();
}