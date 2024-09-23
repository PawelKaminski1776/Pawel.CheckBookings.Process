using NServiceBus;
namespace BowlingSys.Entities.BookingDBEntities
{


    public class GetLaneResult : IMessage
    {
        public int laneID { get; }
    }
}
