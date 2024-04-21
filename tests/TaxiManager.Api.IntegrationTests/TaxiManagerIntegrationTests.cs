using System.Net;
using FluentAssertions;
using Newtonsoft.Json.Linq;
using TaxiManagerDomain.Dtos;

namespace TaxiManager.Api.IntegrationTests
{
    public class TaxiManagerIntegrationTests : IClassFixture<TaxiManagerFixture>
    {
        private readonly TaxiManagerFixture _fixture;

        public TaxiManagerIntegrationTests(TaxiManagerFixture fixture)
        {
            _fixture = fixture;
        }

        #region  AutoPart
        [Fact(DisplayName = "Create AutoPart [Success]")]
        public async Task CreateAutoPart_Success()
        {
            // Arrange
            var url = "api/autopart/create";
            var autoPartDto = new AutoPartDto
            {
                AutoPartName = "Kit Clutch Renault",
                Price = 180000.00M,
                WhereItWasPurchased = new AddressDto{
                    Street = "Calle 19",
                    City = "Cucuta",
                    State = "NS",
                    Zipcode = "123456",
                }
            };

            var autoPartDtoJson = JToken.FromObject(autoPartDto).ToString();

            // Act
            var (responseObject, StatusCode) = await _fixture.PostInAPi(url, autoPartDtoJson);

            // Assert
            StatusCode.Should().Be(HttpStatusCode.OK);
            Assert.IsType<Guid>(responseObject);
        }
        #endregion

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