using AluraDev.Data;
using AluraDev.Domain.Interfaces;
using AluraDev.Repository;
using AluraDev.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<AluraDevDataSettings>(
    builder.Configuration.GetSection("AluraDevData"));

// Services
builder.Services.AddScoped<IProjetoService, ProjetoService>();

// Repositories
builder.Services.AddSingleton<IProjetoRepository, ProjetoRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(
    option => option.AllowAnyOrigin()
                    .AllowAnyHeader()
                    .AllowAnyMethod());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
