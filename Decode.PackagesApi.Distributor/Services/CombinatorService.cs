using Decode.PackagesApi.Distributor.Common.Models;
using Decode.PackagesApi.Distributor.Common.Options;
using Decode.PackagesApi.Distributor.Services.Interfaces;
using System.Text.Json;

namespace Decode.PackagesApi.Distributor.Services
{
    public class CombinatorService : ICombinatorService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly CombinatorOptions combinatorOptions;

        public CombinatorService(IHttpClientFactory httpClientFactory, CombinatorOptions combinatorOptions)
        {
            _httpClientFactory = httpClientFactory;
            this.combinatorOptions = combinatorOptions;
        }

        public Task<PackagesBookResponse> BookAsync(PackagesBookRequest request)
        {
            throw new NotImplementedException();
        }

        public async Task<PackagesSearchResponse> SearchAsync(PackagesSearchRequest request)
        {
            var httpRequestMessage = new HttpRequestMessage(HttpMethod.Get, combinatorOptions.URL);

            var httpClient = _httpClientFactory.CreateClient();
            var httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);

            if (httpResponseMessage.IsSuccessStatusCode)
            {
                using var contentStream =
                    await httpResponseMessage.Content.ReadAsStreamAsync();

                var t = await JsonSerializer.DeserializeAsync
                    <IEnumerable<object>>(contentStream);
            }
            throw new NotImplementedException();
        }

        public Task<PackagesValidateResponse> ValidateAsync(PackagesValidateRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
