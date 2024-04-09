using ExploreTheProgramCsFile.NewFolder;
using ExploreTheProgramCsFile.Scoped;
using ExploreTheProgramCsFile.Singleton;
using Microsoft.AspNetCore.Mvc;

namespace ExploreTheProgramCsFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
     
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;
        private readonly ISingletonService _singletonService;

        public WeatherForecastController(ITransientService transientService, IScopedService scopedService, ISingletonService singletonService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
            _singletonService = singletonService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new
            {
                Transient = _transientService.GetOperationId(),
                Scoped = _scopedService.GetOperationId(),
                Singleton = _singletonService.GetOperationId()
            }); 
        }
    }
}
