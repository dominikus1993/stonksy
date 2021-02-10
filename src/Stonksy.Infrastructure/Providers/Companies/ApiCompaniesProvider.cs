using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;
using Stonksy.Core.Providers.Companies;

namespace Stonksy.Infrastructure.Providers.Companies
{
    internal class ApiCompaniesProvider : ICompaniesProvider
    {
        public IAsyncEnumerable<Company> ProvideCompanies(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}