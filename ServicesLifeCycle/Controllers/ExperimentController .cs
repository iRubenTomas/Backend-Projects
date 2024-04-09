using ExploreTheProgramCsFile.NewFolder;
using ExploreTheProgramCsFile.Scoped;
using Microsoft.AspNetCore.Mvc;

namespace ExploreTheProgramCsFile.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExperimentController : ControllerBase
    {
        private readonly ITransientService _transientService;
        private readonly IScopedService _scopedService;

        public ExperimentController(ITransientService transientService, IScopedService scopedService)
        {
            _transientService = transientService;
            _scopedService = scopedService;
        }

        [HttpGet("transient")]
        public IActionResult GetTransient()
        {
            var operationId = _transientService.GetOperationId();
            return Ok($"Transient: {operationId}");
        }

        [HttpGet("scoped")]
        public IActionResult GetScoped()
        {
            var operationId = _scopedService.GetOperationId();
            return Ok($"Scoped: {operationId}");
        }
    }
}
