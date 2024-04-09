using ExploreTheProgramCsFile.NewFolder;
using Microsoft.AspNetCore.Mvc;

namespace ExploreTheProgramCsFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ActivityController : ControllerBase
    {
        private readonly IUserSessionService _sessionService;

        public ActivityController(IUserSessionService sessionService)
        {
            _sessionService = sessionService;
        }

        [HttpPost]
        public IActionResult LogActivity([FromBody] string activity)
        {
            _sessionService.LogActivity(activity);
            return Ok("Activity logged");
        }

        [HttpGet]
        public IActionResult GetActivities()
        {
            return Ok(_sessionService.GetActivities());
        }
    }
}
