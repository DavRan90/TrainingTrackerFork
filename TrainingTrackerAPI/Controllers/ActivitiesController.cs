using Microsoft.AspNetCore.Mvc;
using TrainingTrackerAPI.Data;
using TrainingTrackerAPI.Models;

namespace TrainingTrackerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ActivitiesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public ActivitiesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> CreateRunning([FromBody] DTO.ActivitesCreateDto newActivity)
        {
            var running = new Running
            {
                Name = newActivity.Name,
                Distance = newActivity.Distance,
                ActivityDate = DateTime.UtcNow,
                TotalTimeInSeconds = 0,
                AverageCadence = 0
            };
            _context.Activities.Add(running);
            await _context.SaveChangesAsync();

            return Ok(running);
        }
    }
}
