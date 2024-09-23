using BowlingSys.DBConnect;
using BowlingSys.Entities.BookingDBEntities;
using System.Data.SqlClient;
using System.Data;

namespace BowlingSys.Services.BookingService
{
    public class BookingService
    {
        private DBConnect.DBConnect _DBConnect;

        public BookingService( DBConnect.DBConnect dBConnect)
        {
            _DBConnect = dBConnect;
        }

        public async Task<GetLaneResult> CallGetLane_SP(int bookingid)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@BookingId", SqlDbType.Int) { Value = bookingid },
            };
            return (GetLaneResult)_DBConnect.SelectAndRunStoredProcedure("GetLane", parameters);
        }
    }
}
