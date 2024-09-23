using NServiceBus;

namespace BowlingSys.Contracts.BookingDtos
{
    public class BookingDto : IMessage
    {
        public int BookingID { get; set; }
    }
}
