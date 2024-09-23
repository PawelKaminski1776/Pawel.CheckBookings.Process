using BowlingSys.Contracts.BookingDtos;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using NServiceBus.Transport;
using BowlingSys.Services.BookingService;
using BowlingSys.Entities.BookingDBEntities; 

namespace BowlingSys.Handlers.Handlers
{
    public class MyMessageHandler :
    IHandleMessages<BookingDto>
    {
        BookingService _bookingService;
        public MyMessageHandler(BookingService bookingService) {
            _bookingService = bookingService;
        }
        public Task Handle(BookingDto message, IMessageHandlerContext context)
        {
            var otherMessage = new GetLaneResult();
            Console.WriteLine($"Yes Yes Yes \n\n\n\n\n YEs YES");
            return Task.CompletedTask;
        }
    }

}
