using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Net.Http.Json;
using TrainingTrackerAPI.DTO;
using TrainingTrackerAPI.Models;

namespace TrainingTracker.Tests.TrainingTrackerAPITests
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
            var userId = "test-user-id";
            var requestUri = $"/api/activities?userId={userId}";

            //Act
            var response = await _httpClient.GetAsync(requestUri);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
            Assert.True(response.Content.Headers.ContentLength > 0);

        }
    }
}
