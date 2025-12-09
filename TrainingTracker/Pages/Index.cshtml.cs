using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Globalization;
using TrainingTracker.Models;
using TrainingTracker.Service;
using TrainingTracker.ViewModel;
using TrainingTrackerAPI.Models;
using TrainingTrackerAPI.Services;


public class IndexModel : PageModel
{
    private readonly ActivityAPIManager _api;
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly ActivitySummaryService _activitySummaryService;

    public IndexModel(ActivityAPIManager api, UserManager<ApplicationUser> user, ActivitySummaryService activitySummaryService)
    {
        _api = api;
        _userManager = user;
        _activitySummaryService = activitySummaryService;
    }

    public List<ActivityViewModel> Activities { get; set; } = new();
    public List<DateTime> ActivityDates { get; set; } = new();
    public ActivityTotals ActivityTotal { get; set; } = new();

    public async Task OnGetAsync()
    {
        var userId = _userManager.GetUserId(User);
        if(userId != null)
            Activities = await _api.GetAllActivities(userId);

        // Lista med datum för kalender
        ActivityDates = Activities
            .Select(a => a.ActivityDate.Date.ToUniversalTime())
            .Distinct()
            .ToList();

        ActivityTotal = _activitySummaryService.CalculateActivityIntervals(Activities);
    }
}
