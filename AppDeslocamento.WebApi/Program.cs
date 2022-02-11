using AppDeslocamento.Data.Context;
using AppDeslocamento.Data.Repository;
using AppDeslocamento.Domain.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

///////// aqui inicia o que foi adicionado para o projeto
////adiciona o contexto aos serviços       
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("ApplicationDbContext"),
        b => b.MigrationsAssembly("AppDeslocamento.Data"));
});

builder.Services.AddTransient<IUnityOfWork, UnityOfWork>();

var appAssemblie = typeof(
    AppDeslocamento.Application.Carros.Commands.CriarCarro.CriarCarroCommand)
    .Assembly;
builder.Services.AddMediatR(appAssemblie);

builder.Services.AddControllersWithViews()
    .AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

///////////////// fim
///
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
