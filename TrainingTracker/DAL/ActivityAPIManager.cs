using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using TrainingTrackerAPI.DTO;
using TrainingTrackerAPI.Models;

namespace TrainingTracker.DAL
{
    public class ActivityAPIManager
    {
        private readonly HttpClient _http;
        public ActivityAPIManager(IHttpClientFactory factory)
        {
            _http = factory.CreateClient("Backend");
        }

        public async Task<ActivityDto> SaveActivity(ActivitesCreateDto activity)
        {
            var response = await _http.PostAsJsonAsync("/api/Activities", activity);
            if(response.IsSuccessStatusCode)
            {
                var createdActivity = response.Content.ReadFromJsonAsync<ActivityDto>().Result;
                return createdActivity ?? new ActivityDto();
            }
            else
            {
                return new ActivityDto();
            }
        }

        public async Task<List<ActivityDto>> GetAllActivities()
        {
            try
            {
                var activities = await _http.GetFromJsonAsync<List<ActivityDto>>("/api/Activities");
                return activities ?? new List<ActivityDto>();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<ActivityDto>();
            }

        }
        public async Task<ActivityDto> GetActivity(int id)
        {
            try
            {
                var activity = await _http.GetFromJsonAsync<ActivityDto>($"/api/Activities/{id}");
                return activity ?? new ActivityDto();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new ActivityDto();
            }
            
        }

        public async Task<bool> UpdateActivity(ActivitesCreateDto activity, int id)
        {
            var response = await _http.PutAsJsonAsync($"/api/Activities/{id}", activity);
            return response.IsSuccessStatusCode;
        }

        public  async Task DeleteActivity(int id)
        {
            var response = await _http.DeleteAsync($"api/activities/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
