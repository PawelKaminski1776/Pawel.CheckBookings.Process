using NServiceBus;

namespace BowlingSys.Contracts.BookingDtos
{
    public class BookingDto : IMessage
    {
        public string user_Id;
    }
}
