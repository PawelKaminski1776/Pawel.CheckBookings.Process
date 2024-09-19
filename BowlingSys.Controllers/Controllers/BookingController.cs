using Microsoft.AspNetCore.Mvc;

namespace BowlingSys.Process.Controllers
{
    [ApiController]
    [Route("Api/BookingController")]
    public class BowlingSysController : ControllerBase
    {

        private readonly ILogger _logger;

        public BowlingSysController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetLane")]
        public IActionResult Get(int booking_ID)
        {
            // Get Lane Method

            return Ok();
        }

    }
}

