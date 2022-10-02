using Stonksy.Core.Types;

namespace Stonksy.Core.Providers;

public interface IStockDataProvider
{
    Task<Stock?> Provide(Symbol symbol, CancellationToken cancellationToken = default);
}