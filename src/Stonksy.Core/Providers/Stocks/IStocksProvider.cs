using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;

namespace Stonksy.Core.Providers.Stocks
{
    public interface IHistoricalStockDataProvider
    {
        IAsyncEnumerable<CompanyStock> Provide(CancellationToken cancellationToken = default);
    }
}