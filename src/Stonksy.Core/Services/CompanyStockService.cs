using System.Collections.Generic;
using System.Threading;
using Stonksy.Core.Model;
using Stonksy.Core.Providers.Companies;

namespace Stonksy.Core.Services
{
    public class CompanyStockService : ICompanyStockService
    {
        private ICompaniesProvider _companiesProvider;

        public CompanyStockService(ICompaniesProvider companiesProvider)
        {
            _companiesProvider = companiesProvider;
        }

        public IAsyncEnumerable<CompanyStock> Get(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}