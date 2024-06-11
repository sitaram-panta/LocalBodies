using Local_Api.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Local_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsController : ControllerBase
    {
        private readonly IDatabaseHelper _databaseHelper;

        public LogsController(IDatabaseHelper databaseHelper)
        {
            _databaseHelper = databaseHelper;
        }

        public class Log
        {
            public int LogId { get; set; }
            public string Message { get; set; }
            // Add other properties as needed
        }

        [HttpGet]
        public IActionResult GetLogs()
        {
            try
            {
                var logs = _databaseHelper.ExecuteQuery<Log>();
                return Ok(logs);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occur during the retrieval of logs
                return StatusCode(500, "Failed to retrieve logs");
            }
        }

    }
}
