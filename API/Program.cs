using API.Extensions;
using API.Middleware;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Added all the things from below to AddApplicationServices static class
builder.Services.AddApplicationServices(builder.Configuration);


var app = builder.Build();

// Configure the HTTP request pipeline.

// Middleware
app.UseMiddleware<ExceptionMiddleware>();

// Hidden middleware to see Developer Exception Page because once we are in production, we are unable to see this errors.
app.UseStatusCodePagesWithReExecute("/errors/{0}");

//// Commenting this if statement as this app will not be target for production
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}

//app.UseHttpsRedirection();
// This will show the static files such as images
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

// Apply any migrations if not applied yet 
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreContext>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    await StoreContextSeed.SeedAsync(context);
}
catch(Exception ex)
{
    logger.LogError(ex, "An error occured during Migration");
}

app.Run();
