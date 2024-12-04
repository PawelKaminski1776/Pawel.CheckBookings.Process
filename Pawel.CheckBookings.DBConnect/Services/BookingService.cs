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

        public async Task<GetBookingsResponse> CallGetBookingDetailsByUserId(Guid user_id)
        {
            var parameters = new[]
            {
                new NpgsqlParameter("p_user_id", NpgsqlTypes.NpgsqlDbType.Uuid) { Value = user_id }
             };

            var finalResults = new GetBookingsResponse { Results = new List<GetBookingsResult>() };

            try
            {
                var result = (List<Dictionary<string, object>>)await _DBConnect.SelectAndRunFunction("SELECT * FROM dbo.getbookingsbyuserid(@p_user_id)", parameters);

                foreach (var row in result)
                {
                    var booking = new GetBookingsResult
                    {
                        booking_date = row.GetValueOrDefault("booking_date")?.ToString() ?? string.Empty,
                        booking_time = row.GetValueOrDefault("booking_time")?.ToString() ?? string.Empty,
                        booking_status = row.GetValueOrDefault("booking_status")?.ToString() ?? string.Empty,
                        numofshoes = Convert.ToInt32(row.GetValueOrDefault("numofshoes") ?? 0),
                        booking_cost = Convert.ToSingle(row.GetValueOrDefault("booking_cost") ?? 0f),
                        lane_id = Convert.ToInt32(row.GetValueOrDefault("lane_id") ?? 0),
                        user_id = Guid.TryParse(row.GetValueOrDefault("user_id")?.ToString(), out var parsedUserId) ? parsedUserId : Guid.Empty
                    };

                    finalResults.Results.Add(booking);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while fetching booking details: {ex.Message}");

                throw new ApplicationException("Failed to retrieve booking details. Please try again later.", ex);
            }

            return finalResults;
        }








    }
}
