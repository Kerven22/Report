using Microsoft.AspNetCore.Mvc;

namespace Report.Cotrollers
{
    [ApiController]
    [Route("report")]
    public class ReportController:ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetProductReport(Guid prodctId)
        {
            return Ok("report getting"); 
        }
    }
}
