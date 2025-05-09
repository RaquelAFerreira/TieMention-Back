using TieMention.Application;
using TieMention.Infrastructure;
using TieMention.Presentation;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddPresentation();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Adicione os serviços de autenticação/authorização se necessário
builder.Services.AddAuthorization(); // ← Solução para o erro

var app = builder.Build();

// Configure the HTTP request pipeline
app.UseHttpsRedirection();

// Agora esta linha não causará erro
app.UseAuthorization();

app.MapEndpoints();

app.Run();