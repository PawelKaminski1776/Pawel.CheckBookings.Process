using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using BowlingSys.Contracts.BookingDtos;
using BowlingSys.Entities.BookingDBEntities;
using System.Threading.Tasks;

namespace BowlingSys.Process.Controllers
{
    [ApiController]
    [Route("Api/Booking")]
    public class BowlingSysController : BaseController
    {
        public BowlingSysController(IMessageSession messageSession) : base(messageSession)
        {
        }

        [HttpGet("getBookings")]
        public async Task<IActionResult> GetUserBookings(string userid)
        {
            
            try
            {
                BookingDto dto = new BookingDto
                {
                    user_Id = userid,
                };
                var response = await _messageSession.Request<GetBookingsResponse>(dto);
                return Ok(response);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error while processing the request: {ex.Message}");
            }
        }
    }
}
