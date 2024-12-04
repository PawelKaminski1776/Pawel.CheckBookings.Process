using NServiceBus;
namespace BowlingSys.Entities.BookingDBEntities
{
    public class GetBookingsResult
    {
        public int booking_id { get; set; }
        public string booking_date { get; set; }
        public string booking_time { get; set; }
        public string booking_status { get; set; }
        public int numofshoes { get; set; }
        public float booking_cost { get; set; }
        public int lane_id { get; set; }
        public Guid user_id { get; set; }
    }

    public class GetBookingsResponse : IMessage
    {
        public List<GetBookingsResult> Results { get; set; }
    }
}
