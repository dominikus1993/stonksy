using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;

namespace Stonksy.Core.Providers.Companies
{
    public interface ICompaniesProvider
    {
        IAsyncEnumerable<Company> ProvideCompanies(CancellationToken cancellationToken);
    }
}