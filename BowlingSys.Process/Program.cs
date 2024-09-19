using NServiceBus;
using Azure.Messaging.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var endpointConfiguration = new EndpointConfiguration("EndpointName");
var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();

transport.ConnectionString("YourServiceBusConnectionString");

var app = builder.Build();
// Configure the HTTP request pipeline.
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
