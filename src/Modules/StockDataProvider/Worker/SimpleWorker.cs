using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using StockDataProvider.Services;

namespace StockDataProvider.Worker;

internal class SimpleWorker : BackgroundService
{
    private ILogger<SimpleWorker> _logger;
    private IStockDataProvider _stockDataProvider;

    public SimpleWorker(ILogger<SimpleWorker> logger, IStockDataProvider stockDataProvider)
    {
        _logger = logger;
        _stockDataProvider = stockDataProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogError("xDDDD");
            await Task.Delay(10000, stoppingToken);
        }
    }
}