using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Dynastream.Fit;
using System.Text.Json;
using TrainingTracker.FitConversion;
using TrainingTracker.DAL;
using Microsoft.AspNetCore.Identity;
using TrainingTracker.Models;
using TrainingTrackerAPI.Models;

namespace TrainingTracker.Pages
{
    
    
    public class ImportModel : PageModel
    {
        private readonly ActivityAPIManager _api;
        private readonly UserManager<ApplicationUser> _userManager;
        public ImportModel(ActivityAPIManager api, UserManager<ApplicationUser> userManager)
        {
            _api = api;
            _userManager = userManager;
        }
        [BindProperty]
        public IFormFile? FitFile { get; set; }

        public string? JsonOutput { get; set; }
        [BindProperty]
        public string? SessionTitle { get; set; }
        public TrainingTracker.FitConversion.SessionInfo? Session { get; set; }
        public async Task<IActionResult> OnPostAsync()
        {
            if (FitFile == null)
            {
                JsonOutput = "No file uploaded.";
                return Page();
            }

            using var stream = FitFile.OpenReadStream();

            JsonOutput = FitToJson.ExtractSessionToJson(stream);

            // JSON is an array ? so deserialize a list
            var list = JsonSerializer.Deserialize<List<TrainingTracker.FitConversion.SessionInfo>>(JsonOutput);

            Session = list?.FirstOrDefault();
            Session.ActivityName = SessionTitle;
            var user = await GetCurrentUserAsync();
            Session.UserId = user.Id;
            await _api.UploadActivity(Session);

            return Page();
        }
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(User);
        }
    }
}
