using BowlingSys.DBConnect;
using BowlingSys.Entities.BookingDBEntities;
using System.Data.SqlClient;
using System.Data;

namespace BowlingSys.Services.BookingService
{
    public class BookingService
    {
        private readonly string _connectionString;
        private DBConnect.DBConnect _DBConnect;

        public BookingService(string connectionString, DBConnect.DBConnect dBConnect)
        {
            _connectionString = connectionString;
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
