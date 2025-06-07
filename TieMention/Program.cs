using TieMention.Application;
using TieMention.Infrastructure;
using TieMention.Presentation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddApplication().AddInfrastructure(builder.Configuration).AddPresentation();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddAuthorization();

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapEndpoints();

app.Run();
