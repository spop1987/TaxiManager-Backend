using System.Net;
using FluentAssertions;

namespace TaxiManager.Api.IntegrationTests
{
    public class TaxiManagerIntegrationTests : IClassFixture<TaxiManagerFixture>
    {
        private readonly TaxiManagerFixture _fixture;

        public TaxiManagerIntegrationTests(TaxiManagerFixture fixture)
        {
            _fixture = fixture;
        }

        #region User
        [Fact(DisplayName = "Get Driver [Success]")]
        public async Task GetDriver_Success()
        {
            // Arrange
            var url = $"api/user/emailexists?email=adminTest@mail.com";

            // Act
            var (responseObject, StatusCode) = await _fixture.GetInApi(url);

            // Assert
            responseObject.Should().Be("true");
            StatusCode.Should().Be(HttpStatusCode.OK);
        }
        #endregion


    }
}