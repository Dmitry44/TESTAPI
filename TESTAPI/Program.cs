using System.Globalization;
using Mediator;
using Microsoft.AspNetCore.Diagnostics;
using System.Reflection;
using TESTAPI.Services;

// Set the culture for the API
var cultureInfo = new CultureInfo("de-DE");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddHttpClient();
builder.Services.AddSingleton<IDataService, DataService>();
builder.Services.AddMediator();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseExceptionHandler(c => c.Run(async context =>
{
    var exception = context.Features
        ?.Get<IExceptionHandlerPathFeature>()
        ?.Error;
    var response = new { error = exception?.Message ?? "Internal Server Error" };
    await context.Response.WriteAsJsonAsync(response);
}));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
