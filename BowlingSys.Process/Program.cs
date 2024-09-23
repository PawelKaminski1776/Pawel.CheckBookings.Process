using NServiceBus;
using Azure.Messaging.ServiceBus;
using NServiceBus.Extensions.Hosting;
using Newtonsoft;
using NServiceBus.Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;
using System.Globalization;
using BowlingSys.Services.BookingService;
using BowlingSys.Handlers.Handlers;
using BowlingSys.Entities.BookingDBEntities;
using BowlingSys.DBConnect;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<MyMessageHandler>();
builder.Services.AddScoped<DBConnect>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new DBConnect(connectionString);
});
builder.Services.AddScoped<BookingService>(provider =>
{
    var dbConnect = provider.GetRequiredService<DBConnect>();
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    return new BookingService(connectionString, dbConnect);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var endpointConfiguration = new EndpointConfiguration("BowlingSys");

var settings = new JsonSerializerSettings
{
    TypeNameHandling = TypeNameHandling.Auto,
    Converters =
    {
        new IsoDateTimeConverter
        {
            DateTimeStyles = DateTimeStyles.RoundtripKind
        }
    }
};
var serialization = endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();
serialization.Settings(settings);


var transport = endpointConfiguration.UseTransport<LearningTransport>();

var routing = transport.Routing();
routing.RouteToEndpoint(typeof(GetLaneResult), "DestinationEndpoint");

builder.UseNServiceBus(endpointConfiguration);

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });
}
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
