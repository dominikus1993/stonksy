using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;

namespace Stonksy.Core.Services
{
    public interface ICompanyStockService
    {
        IAsyncEnumerable<CompanyStock> Get(CancellationToken cancellationToken);
    }
}