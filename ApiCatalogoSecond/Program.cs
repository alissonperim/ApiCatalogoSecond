using ApiCatalogoSecond.AppServicesExtensions;
using ApiCatalogoSecond.DTOs.Mappings;
using ApiCatalogoSecond.Endpoints;
using ApiCatalogoSecond.Extensions.Exceptions;
using ApiCatalogoSecond.Repositories;
using ApiCatalogoSecond.Repositories.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

app.UseHttpsRedirection();
app.Endpoints();

app.Run();
