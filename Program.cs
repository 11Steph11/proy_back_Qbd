using Microsoft.EntityFrameworkCore;
using DotNetEnv;
using Proy_back_QBD.Data;
using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using Proy_back_QBD.Profiles;
using Proy_back_QBD.Services;
using Proy_back_QBD.Repository;
Env.Load(); // Cargar variables de entorno desde el archivo .env

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAutoMapper(cfg =>
{
    cfg.AddProfile<TrabajadorMappingProfile>();  // Registra tu perfil explícitamente
});
builder.Services.AddScoped<ITrabajadorRepository, TrabajadorRepository>();
builder.Services.AddScoped<ITrabajadorService, TrabajadorService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<AuthService>();
// Configurar servicios
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configurar conexión a PostgreSQL
var configuration = builder.Configuration;
var connectionString = configuration.GetConnectionString("DefaultConnection") ??
    $"Host={configuration["POSTGRES_HOST"]};" +
    $"Port={configuration["POSTGRES_PORT"]};" +
    $"Username={configuration["POSTGRES_USERNAME"]};" +
    $"Password={configuration["POSTGRES_PASSWORD"]};" +
    $"Database={configuration["POSTGRES_DB"]}";

Console.WriteLine($"Connection String: {connectionString}");

builder.Services.AddDbContext<ApiContext>(options =>
    options.UseNpgsql(connectionString));

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowSpecificOrigins", builder =>
    {
        builder.WithOrigins() // Especifica orígenes permitidos en producción
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configurar el pipeline
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "API v1");
        options.RoutePrefix = string.Empty; // Swagger en la raíz
    });
}

app.UseHttpsRedirection();
app.UseCors("AllowSpecificOrigins");
app.UseRouting();
app.MapControllers();

app.Run();