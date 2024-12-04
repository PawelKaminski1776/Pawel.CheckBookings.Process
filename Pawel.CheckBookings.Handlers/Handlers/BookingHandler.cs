using NServiceBus;
using BowlingSys.Contracts.BookingDtos;
using BowlingSys.Services.BookingService;
using BowlingSys.Entities.BookingDBEntities;

namespace BowlingSys.Handlers.Handlers
{
    public class MyMessageHandler : IHandleMessages<BookingDto>
    {
        private readonly BookingService _bookingService;

        public MyMessageHandler(BookingService bookingService)
        {
            _bookingService = bookingService;
        }

        public async Task Handle(BookingDto message, IMessageHandlerContext context)
        {
            try
            {
                var Result = await _bookingService.CallGetBookingDetailsByUserId(new Guid(message.user_Id));

                await context.Reply(Result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while processing the message: {ex.Message}");
            }
        }
    }
}