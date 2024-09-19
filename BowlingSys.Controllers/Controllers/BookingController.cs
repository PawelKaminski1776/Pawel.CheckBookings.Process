using Microsoft.AspNetCore.Mvc;
using NServiceBus;

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
        public async Task Get(int booking_ID)
        {
            // Get Lane Method
            var message = new MyMessage();
            return Ok();
        }

    }
}

