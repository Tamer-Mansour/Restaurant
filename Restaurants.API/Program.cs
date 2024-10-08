// Create object (WebApplicationBuilder) using the static way:
// (WebApplication.CreateBuilder) then pass the (args)
// (args): It is a set of parameters that are passed to the web
// application from the command line (such as configuration options).
using Restaurants.Infrastructure.Extensions;
using Restaurants.Infrastructure.Seeders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// here we add service to the service contaioner, that mean we add
// the (AddControllers) that used to support the web api or mvc,
// that measn our application used the controller for hanle requests
builder.Services.AddControllers();


builder.Services.AddInfrastructre(builder.Configuration);

// build the application after after set all services
var app = builder.Build();
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<IRestaurantSeeder>();

await seeder.Seed();

// Configure the HTTP request pipeline.
// is middleware that can gide requests to use the spicific protocal
app.UseHttpsRedirection();

// is middleware that can check the autherizations
app.UseAuthorization();

// set the endpoint for the controllers
app.MapControllers();

// run the application
app.Run();