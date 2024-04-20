using System.Net;
using Microsoft.AspNetCore.Mvc.Testing;

namespace TaxiManager.Api.IntegrationTests
{
    public class TaxiManagerFixture
    {
        private readonly TaxiManagerWebApplicationFactory _factory;
        public HttpClient _client;
        public TaxiManagerFixture()
        {
            _factory = new();
            _client = _factory.CreateClient(new WebApplicationFactoryClientOptions
            {
                AllowAutoRedirect = false
            });
        }

        public async Task<(string Response, HttpStatusCode StatusCode)> GetInApi(string url)
        {
            var response = await _client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return (responseContent, response.StatusCode);
        }
    }
}