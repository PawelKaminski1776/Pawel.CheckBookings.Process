using BowlingSys.DBConnect;
using BowlingSys.Entities.BookingDBEntities;

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

        public GetLaneResult CallGetLane_SP(string StoredProcedure, string[] parameters)
        {
            GetLaneResult result = (GetLaneResult)_DBConnect.SelectAndRunStoredProcedure("GetLane", parameters);
            return result;
        }
    }
}
