using System.Net;
using System.Text;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json.Linq;

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

        public async Task<(Guid Id, HttpStatusCode StatusCode)> PostInAPi(string url, string jsonBody, string source = null)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = CreateHttpJsonBody(jsonBody),
            };
            request.Headers.Add("source", source);
            var response = await _client.SendAsync(request);
            var responseContent = await response.Content.ReadAsStringAsync();
            var dto = JToken.Parse(responseContent).ToObject<Guid>();

            return (dto, response.StatusCode);
        }

        private StringContent CreateHttpJsonBody(string jsonBody)
        {
            return new StringContent(jsonBody, Encoding.UTF8, "application/json");
        }
    }
}