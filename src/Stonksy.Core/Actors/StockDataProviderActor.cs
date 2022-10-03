using Akka.Actor;

using Stonksy.Core.Actors.Messages;
using Stonksy.Core.Providers;

namespace Stonksy.Core.Actors;

public class StockDataProviderActor : ReceiveActor
{
    private readonly IStockDataProvider _provider;

    public StockDataProviderActor(IStockDataProvider provider)
    {
        _provider = provider;
    }

    private void OnReady()
    {
        ReceiveAsync<DownloadStockData>(msg => OnDownloadStockData(msg));
    }

    private async Task OnDownloadStockData(DownloadStockData msg)
    {
        var data = await _provider.Provide(msg.Symbol);
    }



    public static Props Props(IStockDataProvider provider)
    {
        return Akka.Actor.Props.Create(() => new StockDataProviderActor(provider));
    }
}