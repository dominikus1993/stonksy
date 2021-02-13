using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using CsvHelper;
using Stonksy.Core.Model;
using Stonksy.Core.Providers.Companies;
using Stonksy.Infrastructure.Dtos;

namespace Stonksy.Infrastructure.Providers.Companies
{
    internal class ApiCompaniesProvider : ICompaniesProvider
    {
        private const string CsvFileUrl =
            "https://pkgstore.datahub.io/core/nasdaq-listings/nasdaq-listed_csv/data/7665719fb51081ba0bd834fde71ce822/nasdaq-listed_csv.csv";

        public const string CompaniesApi = nameof(ApiCompaniesProvider);

        private readonly HttpClient _client;

        public ApiCompaniesProvider(IHttpClientFactory factory)
        {
            _client = factory.CreateClient(CompaniesApi);
        }


        public async IAsyncEnumerable<Company> ProvideCompanies(
            [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            using var request = new HttpRequestMessage(HttpMethod.Get, CsvFileUrl);
            using var response =
                await _client.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken);
            response.EnsureSuccessStatusCode();
            await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken);
            using var reader = new StreamReader(stream);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            await foreach (var dto in csv.GetRecordsAsync<CompanyDto>().WithCancellation(cancellationToken))
            {
                yield return dto.MapToCompany();
            }
        }
    }
}