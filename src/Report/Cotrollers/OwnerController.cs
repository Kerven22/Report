using Microsoft.AspNetCore.Mvc;

namespace Report.Cotrollers
{
    [ApiController]
    [Route("owner")]
    public class OwnerController:ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetReport()
        {
            return Ok("Getting report"); 
        }
    }
}
