using Microsoft.EntityFrameworkCore;
using TaxiManager.Api.Extensions;
using TaxiManager.Api.Middleware;
using TaxiManagerInfrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();
builder.Services.AddAplicationServices(builder.Configuration);


var app = builder.Build();

app.UseMiddleware<JwtMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<TaxiManagerContext>();
var logger = services.GetRequiredService<ILogger<Program>>();

try
{
    await context.Database.MigrateAsync();

}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migrations");
}



app.Run();

public partial class Program{}

