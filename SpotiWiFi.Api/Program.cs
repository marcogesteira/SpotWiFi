using Microsoft.EntityFrameworkCore;
using SpotiWiFi.Repository;
using SpotiWiFi.Application.Conta.Profile;
using SpotiWiFi.Repository.Repository;
using SpotiWiFi.Application.Conta;
using SpotiWiFi.Application.Streaming;
using IdentityServer4.AccessTokenValidation;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<SpotiWiFiContext>(c =>
{
    c.UseLazyLoadingProxies()
    .UseSqlServer(builder.Configuration.GetConnectionString("SpotiWiFiConnection"));
});

builder.Services.AddAutoMapper(typeof(UsuarioProfile).Assembly);

builder.Services.AddAuthentication(IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options => 
                {
                    options.Authority = "https://localhost:7280";
                    options.ApiName = "SpotiWiFi-api";
                    options.ApiSecret = "SpotiWiFiSecret";
                    options.RequireHttpsMetadata = true;
                });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("spotiwifi-role", p =>
    {
        p.RequireClaim("role", "spotiwifi-user");
    });
});

//Repositories
builder.Services.AddScoped<UsuarioRepository>();
builder.Services.AddScoped<PlanoRepository>();
builder.Services.AddScoped<BandaRepository>();

//Services
builder.Services.AddScoped<UsuarioService>();
builder.Services.AddScoped<BandaService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
