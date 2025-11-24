

namespace TrainingTracker.Tests
{
    public class TrainingTrackerApiHealthCheckerTests : IClassFixture<CustomWebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;
        public TrainingTrackerApiHealthCheckerTests(CustomWebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task HealthCheck_ReturnSuccess_AndJSON()
        {
            //Arrange
            var requestUri = "/api/activities";

            //Act
            var response = await _httpClient.GetAsync(requestUri);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
            Assert.True(response.Content.Headers.ContentLength > 0);

        }
    }
}
