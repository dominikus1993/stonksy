using StockDataProvider.Types;

namespace StockDataProvider.Services;

internal interface IStockDataProvider
{
    IAsyncEnumerable<Stock> Provide(CancellationToken cancellationToken = default);
}