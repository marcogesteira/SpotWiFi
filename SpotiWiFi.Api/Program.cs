using Microsoft.EntityFrameworkCore;
using SpotiWiFi.Repository;
using SpotiWiFi.Application.Conta.Profile;
using SpotiWiFi.Repository.Repository;
using SpotiWiFi.Application.Conta;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SpotiWiFiContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("SpotiWiFiConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

//Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();


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
