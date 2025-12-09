

using Microsoft.AspNetCore.Http.HttpResults;
using System.Net;
using System.Net.Http.Json;
using TrainingTrackerAPI.DTO;
using TrainingTrackerAPI.Models;

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
            var userId = "test-user-id";
            var requestUri = $"/api/activities?userId={userId}";

            //Act
            var response = await _httpClient.GetAsync(requestUri);

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json", response.Content.Headers.ContentType?.MediaType);
            Assert.True(response.Content.Headers.ContentLength > 0);

        }
        [Fact]
        public async Task CreateActivity_ShouldReturnOkAndActivity()
        {
            //Arrange
            var typeOfActivity = "Running";
            var requestUri = "/api/activities";
            ActivitesCreateDto activity = new ActivitesCreateDto
            {
                Name = "Night run",
                Distance = 5,
                ActivityDate = DateTime.Now,
                SportType = Enum.Parse<SportType>(typeOfActivity),
                //Type = "Running"
            };

            //Act
            var response = await _httpClient.PostAsJsonAsync(requestUri, activity);
            var created = await response.Content.ReadFromJsonAsync<ActivitesCreateDto>();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal(created.Name, activity.Name);


        }

        [Theory]
        [InlineData(SportType.Running)]
        [InlineData(SportType.Cycling)]
        [InlineData(SportType.Walking)]
        public async Task CreateValidActivity_ShouldReturnOkAndActivity(SportType typeOfActivity)
        {
            //Arrange
            var requestUri = "/api/activities";
            ActivitesCreateDto activity = new()
            {
                Name = "Run",
                Distance = 5,
                ActivityDate = DateTime.Now,
                //Type = "typeOfActivity",
                SportType = typeOfActivity
            };


            //Act
            var response = await _httpClient.PostAsJsonAsync(requestUri, activity);
            var createdActivity = response.Content.ReadFromJsonAsync<ActivitesCreateDto>();

            //Assert
            response.EnsureSuccessStatusCode();
            Assert.True(createdActivity != null);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData(SportType.Running)]
        [InlineData(SportType.Walking)]
        [InlineData(SportType.Cycling)]
        public async Task UploadActivity_ShouldReturnOk(SportType typeOfActivity)
        {
            //Arrange
            var requestUri = "/api/activities/Upload";
            SessionInfo activity = new()
            {
                ActivityName = "Name",
                TotalDistance = 5,
                StartTime = new(),
                Sport = (int)typeOfActivity,
                TotalTimerTime = 5,
                TotalCalories = 100,
            };


            //Act
            var response = await _httpClient.PostAsJsonAsync(requestUri, activity);
            var createdActivity = await response.Content.ReadFromJsonAsync<ActivitesCreateDto>();

            //Assert
            Assert.True(response.IsSuccessStatusCode);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
