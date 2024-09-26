using BowlingSys.DBConnect;
using BowlingSys.Entities.BookingDBEntities;
using System.Data.SqlClient;
using System.Data;
using Npgsql;
using AutoMapper;

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
            var config = new MapperConfiguration(cfg => cfg.CreateMap<object, GetLaneResult>());
            var mapper = new Mapper(config);
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                 new NpgsqlParameter("@BookingId", SqlDbType.Int) { Value = bookingid },
            };
            return mapper.Map<GetLaneResult>(await _DBConnect.SelectAndRunStoredProcedure("GetLane", parameters));
        }
    }
}
