using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using Stonksy.Core.Model;
using Stonksy.Core.Providers.Companies;

namespace Stonksy.Infrastructure.Providers.Companies
{
    internal class ApiCompaniesProvider : ICompaniesProvider
    {
        public const string CompaniesApi = nameof(ApiCompaniesProvider);
        private HttpClient _client;

        public ApiCompaniesProvider(IHttpClientFactory factory)
        {
            _client = factory.CreateClient(CompaniesApi);
        }
        
        
        public IAsyncEnumerable<Company> ProvideCompanies(CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}