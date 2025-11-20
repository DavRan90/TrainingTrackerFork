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
        public IActionResult CreateActivity(Activity activity)
        {
            _context.Activities.Add(activity);
            _context.SaveChanges();
            return Ok();
        }
    }
}
