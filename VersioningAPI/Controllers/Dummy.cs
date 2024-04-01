using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace VersioningAPI.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/dummy")]
    public class DummyController : ControllerBase
    {
        // Version 1.0 endpoint
        [HttpGet("get-data")]
        [ApiVersion("1.0")]
        public IActionResult GetDataV1()
        {
            return Ok(new { message = "This is version 1.0" });
        }

        // Version 2.0 endpoint
        [HttpGet("get-data")]
        [ApiVersion("2.0")]
        public IActionResult GetDataV2()
        {
            return Ok(new { message = "This is version 2.0" });
        }
    }
}
