using AirlineBookingSystem.Global.ErrorHandlingService;
using AirlineBookingSystem.Global.ErrorHandlingService.Configurations;
using AirlineBookingSystem.Global.ErrorHandlingService.Consumers;
using AirlineBookingSystem.Global.ErrorHandlingService.Interfaces;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddSingleton<IErrorStreamHandlingServiceConfiguration, ErrorStreamHandlingServiceConfiguration>();
builder.Services.AddHostedService<Worker>();

// Adding the address of the eventbus
builder.Services.Configure<EventBusSettings>(
    builder.Configuration.GetSection("EventBusSettings"));

// Registering the consumer for the error stream
builder.Services.AddHostedService<ErrorStreamConsumerService>();

// Adding MediatR handlers
var handlers = HandlerAssemblies.GetMediatRHandlers();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(handlers));

var host = builder.Build();
host.Run();
