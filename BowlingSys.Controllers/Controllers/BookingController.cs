using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using BowlingSys.Contracts.BookingDtos;

namespace BowlingSys.Process.Controllers
{
    [ApiController]
    [Route("Api/BookingController")]
    public class BowlingSysController : BaseController
    {
        public BowlingSysController(IMessageSession messageSession) : base(messageSession)
        {
        }

        [HttpGet(Name = "GetLane")]
        public async Task<IActionResult> Get(int booking_ID)
        {
            BookingDto message = new BookingDto
            {
                BookingID = booking_ID 
            };
            return await HandleMessage(message);
        }

    }
}

