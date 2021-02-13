using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;

namespace Stonksy.Core.Providers.Stocks
{
    public interface IHistoricalStockDataProvider
    {
        IAsyncEnumerable<Stock> Provide(CancellationToken cancellationToken = default);
    }
}