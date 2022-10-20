using StockDataProvider.Types;

namespace StockDataProvider.Services;

internal class YahooFinanceStockDataProvider : IStockDataProvider
{
    public IAsyncEnumerable<Stock> Provide(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}