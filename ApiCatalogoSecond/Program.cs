using ApiCatalogoSecond.AppServicesExtensions;
using ApiCatalogoSecond.Endpoints;
using ApiCatalogoSecond.Extensions.Exceptions;

var builder = WebApplication.CreateBuilder(args);
string? ConnectionString = builder.Configuration.GetConnectionString("DefaultConnectionString");

builder.AddPersistence(ConnectionString)
       .AddApiServices()
       .Services
       .AddCors();

var app = builder.Build();
var Environment = app.Environment;

app.UseExceptionHandler(Environment)
    .UseSwaggerBuilder()
    .UseAppCors();
app.ConfigureExceptionHandler();

app.UseAuthentication();
app.UseAuthorization();

app.UseHttpsRedirection();
app.Endpoints();

app.Run();
